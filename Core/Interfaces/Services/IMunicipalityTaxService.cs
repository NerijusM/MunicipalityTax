using System;
using Core.Entities;
using Shared;

namespace Core.Interfaces.Services;

public interface IMunicipalityTaxService
{
    Task<Result<IEnumerable<MunicipalityTax>>> MunicipalityTaxList();
    Task<Result> SaveMunicipalityTax(MunicipalityTax municipalityTax);
    Task<Result> UpdateMunicipalityTax(MunicipalityTax municipalityTax);
    Task<Result> DeleteMunicipalityTax(MunicipalityTax municipalityTax);
    Result<decimal> MunicipalityTaxByTitleandDate(string title, DateTime date);
}

