using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Shared;

namespace Infrastructure.Services;
public class MunicipalityTaxService : IMunicipalityTaxService
{
    private readonly IMunicipalityTaxRepository _municipalityTaxRepository;

    public MunicipalityTaxService(IMunicipalityTaxRepository municipalityTaxRepository)
    {
        _municipalityTaxRepository = municipalityTaxRepository;
    }

    public async Task<Result> DeleteMunicipalityTax(MunicipalityTax municipalityTax)
    {
        try
        {
            await _municipalityTaxRepository.DeleteAsync(municipalityTax);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Fail($"(Error while deleting MunicipalityTax to db error: {ex.Message})");
        }
    }

    public Task<Result<MunicipalityTax>> MunicipalityTaxByTitleandDate(string title, DateTime date)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> SaveMunicipalityTax(MunicipalityTax municipalityTax)
    {
        try
        {
            await _municipalityTaxRepository.AddAsync(municipalityTax);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Fail($"(Error while writing MunicipalityTax to db error: {ex.Message})");
        }
    }

    public async Task<Result> UpdateMunicipalityTax(MunicipalityTax municipalityTax)
    {
        try
        {
            await _municipalityTaxRepository.UpdateAsync(municipalityTax);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Fail($"(Error while updating MunicipalityTax to db error: {ex.Message})");
        }
    }
}