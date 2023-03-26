using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Types;
using Infrastructure.TaxShedulers;
using Shared;

namespace Infrastructure.Services;

public class MunicipalityTaxService : IMunicipalityTaxService
{
    private readonly IMunicipalityTaxRepository _municipalityTaxRepository;

    public MunicipalityTaxService(IMunicipalityTaxRepository municipalityTaxRepository)
    {
        _municipalityTaxRepository = municipalityTaxRepository;
    }

    public async Task<Result<IEnumerable<MunicipalityTax>>> MunicipalityTaxList()
    {
        var result = await _municipalityTaxRepository.GetAllAsync();

        return Result.Success(result ?? Enumerable.Empty<MunicipalityTax>());
    }

    public async Task<Result> DeleteMunicipalityTax(MunicipalityTax municipalityTax)
    {
        await _municipalityTaxRepository.DeleteAsync(municipalityTax);
        return Result.Success();
    }


    public async Task<Result> SaveMunicipalityTax(MunicipalityTax municipalityTax)
    {
        // FIXME:- move this functionality to entity validation pipeline when implement CQRS
        if (await IsHaveValueFor(municipalityTax))
            return Result.Fail("The tax for this municipality already exists during that period. Please update the record");

        await _municipalityTaxRepository.AddAsync(municipalityTax);
        return Result.Success();
    }

    public async Task<Result> UpdateMunicipalityTax(MunicipalityTax municipalityTax)
    {
        var result = await _municipalityTaxRepository.UpdateMunicipalityTaxAsync(municipalityTax);
        return result;
    }


    public Result<decimal> MunicipalityTaxByTitleandDate(string title, DateTime date)
    {
        IEnumerable<ITaxSheduler> shedulles = TaxSheduler(title, date);

        var result = shedulles
                        .Where(x => x.IsUsed())
                        .OrderBy(a => a.Type.Priority());

        if (!result.Any())
            return Result.Fail<decimal>("No tax was found according to the given criteria");

        var amount = result.First().TaxAmount();

        return Result.Success<decimal>(amount);
    }


    //FIXME: - it can be moved to separate service to collect ITaxSheduler objects
    private IEnumerable<ITaxSheduler> TaxSheduler(string municipality, DateTime date)
    {
        List<ITaxSheduler> shedulles = new()
        {
            new DailyTaxSheduler(_municipalityTaxRepository, municipality, date),
            new WeeklyTaxSheduler(_municipalityTaxRepository, municipality, date),
            new MonthlyTaxSheduller(_municipalityTaxRepository, municipality, date),
            new YearlyTaxAheduler(_municipalityTaxRepository, municipality, date),
        };

        return shedulles;
    }

    private async Task<bool> IsHaveValueFor(MunicipalityTax municipalityTax)
    {
        var result = await _municipalityTaxRepository
                    .FindAsync(x => x.MunicipalityTitle == municipalityTax.MunicipalityTitle &&
                               x.TaxFrom == municipalityTax.TaxFrom &&
                               x.TaxUp == municipalityTax.TaxUp &&
                               x.Type == municipalityTax.Type);
        return result.Any();
    }
}