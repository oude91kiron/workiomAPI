using System;
using Microsoft.AspNetCore.Mvc;
using workiomAPI.Services;
using workiomAPI.Models;

namespace workiomAPI.controllers;

[Controller]
[Route("api/[controller]")]
public class ContactController : Controller {

    private readonly MongoDBService _mongoDBService;

    /*
    * constructor to initialize MongoDBService
    */
    public ContactController(MongoDBService mongoDBService) {

        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Contact>> Get() {
        return await _mongoDBService.GetContactAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact) {
        await _mongoDBService.CreateContactAsync(contact);
        return CreatedAtAction(nameof(Get), new { id = contact.Id}, contact);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> AddToContact(string id, [FromBody] string CompanyIds) {

        await _mongoDBService.AddToContactAsync(id, CompanyIds);
        return NoContent();
    }    


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id) {

        await _mongoDBService.DeleteContactAsync(id);
        return NoContent();
    }




}