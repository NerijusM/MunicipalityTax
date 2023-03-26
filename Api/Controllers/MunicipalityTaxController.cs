using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class MunicipalityTaxController : BaseApiController
{
    public MunicipalityTaxController(ILogger<MunicipalityTaxController> logger):
        base(logger)
    {
        
    }

    [HttpGet("MunicipalityTax")]
    public IActionResult Get()
    {
        return Ok(new List<string>() { "testas" });
    }
}

