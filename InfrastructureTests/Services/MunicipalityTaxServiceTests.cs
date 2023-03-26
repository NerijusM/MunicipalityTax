using System;
using Core.Entities;
using Core.Types;
using Core.Interfaces.Repositories;
using InfrastructureTests.Mocking;
using Infrastructure.Services;

namespace InfrastructureTests.Services;

[TestFixture]
public class MunicipalityTaxServiceTests
{
    private IMunicipalityTaxRepository _municipalityTaxRepository;

    [SetUp]
    public void SetUp()
    {
        _municipalityTaxRepository = new MunicipalityTaxRepositoryStub();
    }

    [Test]
    [TestCase("Vilnius", "2021-01-01", 0.1d)]
    [TestCase("Vilnius", "2021-05-02", 0.4d)]
    [TestCase("Vilnius", "2021-07-10", 0.2d)]
    [TestCase("Vilnius", "2021-03-16", 0.2d)]
    [TestCase("Vilnius", "2021-12-25", 0.1d)]
    public void MunicipalityTaxByTitleandDate_ReturnResultSuccesAndValue(string municipaity, DateTime date, decimal expectedResult)
    {
        var service = new MunicipalityTaxService(_municipalityTaxRepository);

        var result = service.MunicipalityTaxByTitleandDate(municipaity, date);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.Value, Is.EqualTo(expectedResult));
        });
    }

    [Test]
    [TestCase("Kaunas", "2021-01-01", 0.1d)]
    public void MunicipalityTaxByTitleandDate_ReturnResultFalse(string municipaity, DateTime date, decimal expectedResult)
    {
        var service = new MunicipalityTaxService(_municipalityTaxRepository);

        var result = service.MunicipalityTaxByTitleandDate(municipaity, date);
       
        Assert.That(result.IsSuccess, Is.EqualTo(false));
    }
}

