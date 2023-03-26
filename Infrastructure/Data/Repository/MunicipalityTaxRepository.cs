using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repository;

namespace Shared.Repository;
public class MunicipalityTaxRepository : Repository<MunicipalityTax>, IMunicipalityTaxRepository
{
    public MunicipalityTaxRepository(DataContext dbContext) : base(dbContext) { }
}