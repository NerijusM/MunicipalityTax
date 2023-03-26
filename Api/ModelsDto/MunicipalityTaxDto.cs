using System;
using Core.Entities;
using Core.Types;

namespace Api.ModelsDto;

public class MunicipalityTaxDto
{
    public string MunicipalityTitle { get; set; } = string.Empty;
    public DateTime TaxFrom { get; set; }
    public DateTime TaxUp { get; set; }
    public decimal Tax { get; set; }
    public int Type { get; set; }

    public TaxType TaxType { get => this.Type.ToTaxType(); }

    public MunicipalityTax ToCoreObject()
    {
        return new MunicipalityTax()
        {
            MunicipalityTitle = MunicipalityTitle,
            TaxFrom = TaxFrom,
            TaxUp = TaxUp,
            Tax = Tax,
            Type = Type
        };

    }
}

