using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Types;
using Infrastructure.Data;
using Infrastructure.Data.Repository;

namespace Shared.Repository;

public class MunicipalityTaxRepository : Repository<MunicipalityTax>, IMunicipalityTaxRepository
{
    public MunicipalityTaxRepository(DataContext dbContext) : base(dbContext) { }

    public IEnumerable<MunicipalityTax> MunicipalityTaxList(TaxType type, string municipality, DateTime date)
    {
        var result =  Find(tax => tax.Type == (int)type
                            && tax.MunicipalityTitle == municipality
                            && tax.TaxFrom <= date
                            && tax.TaxUp >= date);

        if (result == null) return Enumerable.Empty<MunicipalityTax>();
        return result;
    }

    public async Task<Result> UpdateMunicipalityTaxAsync(MunicipalityTax municipalityTax)
    {
        var municipalityTaxList =
            await FindAsync(x => x.Id.Equals(municipalityTax.Id));
        
        if (municipalityTaxList.Count == 0) return Result.Fail("Can't find any Municipality tax in db");

        var oldMunicipalityTax = municipalityTaxList.First();
        oldMunicipalityTax.UpdateValue(municipalityTax);
        await UpdateAsync(oldMunicipalityTax);

        return Result.Success();
    }
}