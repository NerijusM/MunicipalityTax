using System;
using Core.Interfaces.Repositories;
using Core.Types;

namespace Infrastructure.TaxShedulers;

public class WeeklyTaxSheduler : TaxSheduler
{
    public override TaxType Type => TaxType.Weekly;

    public WeeklyTaxSheduler(IMunicipalityTaxRepository municipalityTaxRepository,
                            string municipality,
                            DateTime date)
        : base(municipalityTaxRepository, municipality, date) { }
}

