using System;
using Core.Entities;
using Core.Types;
using Shared;
using Shared.Repository;

namespace Core.Interfaces.Repositories;

public interface IMunicipalityTaxRepository: IRepository<MunicipalityTax>
{
    Task<Result> UpdateMunicipalityTaxAsync(MunicipalityTax municipalityTax);
    IEnumerable<MunicipalityTax> MunicipalityTaxList(TaxType type,
                                                            string municipality,
                                                            DateTime date);
}

