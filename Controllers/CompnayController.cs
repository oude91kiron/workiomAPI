using System;
using Microsoft.AspNetCore.Mvc;
using workiomAPI.Services;
using workiomAPI.Models;

namespace workiomAPI.controllers;

[Controller]
[Route("api/[controller]")]
public class CompanyController : Controller {

    private readonly MongoDBService _mongoDBService;

    /*
    * constructor to initialize MongoDBService
    */
    public CompanyController(MongoDBService mongoDBService) {

        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Company>> Get() {
        return await _mongoDBService.GetCompanyAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Company company) {
        await _mongoDBService.CreateCompanyAsync(company);
        return CreatedAtAction(nameof(Get), new { id = company.Id}, company);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> AddToCompany(string id, [FromBody] string name) {

        await _mongoDBService.AddToCompanyAsync(id, name);
        return NoContent();
    }    


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id) {

        await _mongoDBService.DeleteCompanyAsync(id);
        return NoContent();
    }




}