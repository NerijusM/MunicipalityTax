using System;
using Core.Interfaces.Repositories;
using Core.Types;

namespace Infrastructure.TaxShedulers;

public class YearlyTaxAheduler : TaxSheduler
{
    public override TaxType Type => TaxType.Yearly;

    public YearlyTaxAheduler(IMunicipalityTaxRepository municipalityTaxRepository,
                            string municipality,
                            DateTime date)
        : base(municipalityTaxRepository, municipality, date) { }
}
