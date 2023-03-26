using System;
using Core.Interfaces.Repositories;
using Core.Types;

namespace Infrastructure.TaxShedulers;

public class DailyTaxSheduler : TaxSheduler
{
    public override TaxType Type => TaxType.Daily;

    public DailyTaxSheduler(IMunicipalityTaxRepository municipalityTaxRepository,
                            string municipality,
                            DateTime date)
        : base(municipalityTaxRepository,municipality, date) {}
}
