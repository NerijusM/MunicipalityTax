using System;
using Core.Entities;
using Core.Types;

namespace Api.ModelsDto;

public class MunicipalityTaxDto
{
    public string Id { get; set; } = string.Empty;
    public string MunicipalityTitle { get; set; } = string.Empty;
    public DateTime TaxFrom { get; set; }
    public DateTime TaxUp { get; set; }
    public decimal Tax { get; set; }
    public int Type { get; set; }

    public TaxType TaxType { get => this.Type.ToTaxType(); }

    public MunicipalityTaxDto()
    {
        
    }

    public MunicipalityTax ToCoreObject()
    {
        return new MunicipalityTax()
        {
            Id = Id, 
            MunicipalityTitle = MunicipalityTitle,
            TaxFrom = TaxFrom,
            TaxUp = TaxUp,
            Tax = Tax,
            Type = Type
        };
    }
}

