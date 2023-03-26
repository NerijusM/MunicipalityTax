using System;
using Api.ModelsDto;
using Core.Entities;

namespace Api.Extensions;

public static class MunicipalityTaxExtensions
{
    public static MunicipalityTaxDto ToDto(this MunicipalityTax model)
    {
        return new MunicipalityTaxDto()
        {
            Id = model.Id,
            MunicipalityTitle = model.MunicipalityTitle,
            TaxFrom = model.TaxFrom,
            TaxUp = model.TaxUp,
            Tax = model.Tax,
            Type = model.Type
        };
    }
}

