using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Types;
using Infrastructure.Data.Repository;
using Shared;

namespace InfrastructureTests.Mocking;

public class MunicipalityTaxRepositoryStub : RepositoryStub<MunicipalityTax>, IMunicipalityTaxRepository
{
    private List<MunicipalityTax> _municipalityTaxes;

    public MunicipalityTaxRepositoryStub()
    {
        _municipalityTaxes = new List<MunicipalityTax> {
                                new MunicipalityTax()
                                {
                                    MunicipalityTitle = "Vilnius",
                                    Tax = 0.2m,
                                    Type = (int)TaxType.Yearly,
                                    TaxFrom = new DateTime(2021, 1, 1, 0, 0, 0),
                                    TaxUp = new DateTime(2021, 12, 31, 23, 59, 0)
                                },

                                new MunicipalityTax()
                                {
                                    MunicipalityTitle = "Vilnius",
                                    Tax = 0.4m,
                                    Type = (int)TaxType.Monthly,
                                    TaxFrom = new DateTime(2021, 5, 1, 0, 0, 0),
                                    TaxUp = new DateTime(2021, 5, 31, 23, 59, 0)
                                },

                                new MunicipalityTax()
                                {
                                    MunicipalityTitle = "Vilnius",
                                    Tax = 0.1m,
                                    Type = (int)TaxType.Daily,
                                    TaxFrom = new DateTime(2021, 1, 1, 0, 0, 0),
                                    TaxUp = new DateTime(2021, 1, 1, 23, 59, 0)
                                },

                                new MunicipalityTax()
                                {
                                    MunicipalityTitle = "Vilnius",
                                    Tax = 0.1m,
                                    Type = (int)TaxType.Daily,
                                    TaxFrom = new DateTime(2021, 12, 25, 0, 0, 0),
                                    TaxUp = new DateTime(2021, 12, 25, 23, 59, 59)
                                }
                            };
    }

    public IEnumerable<MunicipalityTax> MunicipalityTaxList(TaxType type, string municipality, DateTime date)
    {
        var result = _municipalityTaxes.Where(tax => tax.Type == (int)type
                            && tax.MunicipalityTitle == municipality
                            && tax.TaxFrom <= date
                            && tax.TaxUp >= date);

        if (result == null) return Enumerable.Empty<MunicipalityTax>();
        return result;
    }


    public Task<Result> UpdateMunicipalityTaxAsync(MunicipalityTax municipalityTax)
    {
        throw new NotImplementedException();
    }
}

