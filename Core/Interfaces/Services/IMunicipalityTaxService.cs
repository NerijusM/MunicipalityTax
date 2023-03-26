using System;
using Core.Entities;
using Shared;

namespace Core.Interfaces.Services;

public interface IMunicipalityTaxService
{
    Task<Result> SaveMunicipalityTax(MunicipalityTax municipalityTax);
    Task<Result> UpdateMunicipalityTax(MunicipalityTax municipalityTax);
    Task<Result> DeleteMunicipalityTax(MunicipalityTax municipalityTax);
    Task<Result<MunicipalityTax>> MunicipalityTaxByTitleandDate(string title, DateTime date);
}

