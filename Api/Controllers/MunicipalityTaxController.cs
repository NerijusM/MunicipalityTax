using System;
using Api.ModelsDto;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class MunicipalityTaxController : BaseApiController
{
    private readonly IMunicipalityTaxService _municipalityTaxService;

    public MunicipalityTaxController(ILogger<MunicipalityTaxController> logger, IMunicipalityTaxService municipalityTaxService) :
        base(logger)
    {
        _municipalityTaxService = municipalityTaxService;
    }


    [HttpGet("list")]
    public async Task<IActionResult> Add()
    {
        var result = await _municipalityTaxService
                        .MunicipalityTaxList();
        return Ok(result);
    }

    [HttpGet("tax")]
    public IActionResult Tax(string municipality, DateTime date)
    {
        var result = _municipalityTaxService
                        .MunicipalityTaxByTitleandDate(municipality, date);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(MunicipalityTaxDto municipalityTax)
    {
        var result = await _municipalityTaxService
                        .SaveMunicipalityTax(municipalityTax.ToCoreObject());
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(MunicipalityTaxDto municipalityTax)
    {
        var result = await _municipalityTaxService
                        .UpdateMunicipalityTax(municipalityTax.ToCoreObject());
        return Ok(result);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> Remove(MunicipalityTaxDto municipalityTax)
    {
        var result = await _municipalityTaxService
                        .DeleteMunicipalityTax(municipalityTax.ToCoreObject());
        return Ok(result);
    }
}

