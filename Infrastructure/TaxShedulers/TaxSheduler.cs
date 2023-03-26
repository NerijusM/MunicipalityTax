using System;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Types;

namespace Infrastructure.TaxShedulers;

public abstract class TaxSheduler : ITaxSheduler
{
    private readonly string _municipality;
    private readonly DateTime _date;

    private IMunicipalityTaxRepository _municipalityTaxRepository;

    public TaxSheduler(IMunicipalityTaxRepository municipalityTaxRepository, string municipality, DateTime date)
    {
        _municipalityTaxRepository = municipalityTaxRepository;

        _municipality = municipality;
        _date = date;
    }

    public abstract TaxType Type { get; }

    public virtual bool IsUsed()
    {
        var listFiltered = ListOfTax(_municipality, _date);
        return listFiltered.Any();
    }

    public virtual decimal TaxAmount()
    {
        var listFiltered = ListOfTax(_municipality, _date);
        if (!listFiltered.Any())
        {
            return 0m;
        }
        return listFiltered.First().Tax;
    }

    private IEnumerable<MunicipalityTax> ListOfTax(string municipality, DateTime date)
    {
        return _municipalityTaxRepository.MunicipalityTaxList(Type, _municipality, _date);
    }
}

