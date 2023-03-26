using System;
using Core.Interfaces.Repositories;
using Core.Types;

namespace Infrastructure.TaxShedulers;

public class MonthlyTaxSheduller : TaxSheduler
{
    public override TaxType Type => TaxType.Monthly;

    public MonthlyTaxSheduller(IMunicipalityTaxRepository municipalityTaxRepository,
                            string municipality,
                            DateTime date)
        : base(municipalityTaxRepository, municipality, date) { }
}

