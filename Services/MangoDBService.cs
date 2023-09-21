using workiomAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace workiomAPI.Services;

public class MongoDBService {

    private readonly IMongoCollection<Company> _companylistCollection;
    private readonly IMongoCollection<Contact> _contactlistCollection;

    /*
    * init Contstractor to connect to database
    */
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {

        MongoClient client01 = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database01 = client01.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _companylistCollection = database01.GetCollection<Company>(mongoDBSettings.Value.CollectionName1);
        
        MongoClient client02 = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database02 = client01.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _contactlistCollection = database02.GetCollection<Contact>(mongoDBSettings.Value.CollectionName2);
    }


/*
* Company CRUD Methods
*/
    public async Task<List<Company>> GetCompanyAsync() {
        return await _companylistCollection.Find(new BsonDocument()).ToListAsync();
    }


    public async Task CreateCompanyAsync(Company company) {
        await _companylistCollection.InsertOneAsync(company);
        return;
    }

    public async Task AddToCompanyAsync(string id, string name) {
        FilterDefinition<Company> filter = Builders<Company>.Filter.Eq("Id", id);
        UpdateDefinition<Company> update = Builders<Company>.Update.Set<string>("Name", name);
        await _companylistCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteCompanyAsync(string id) {
        FilterDefinition<Company> filter = Builders<Company>.Filter.Eq("Id", id);
        await _companylistCollection.DeleteOneAsync(filter);
        return;
    }


/*
* Contact CRUD Methods
*/
    public async Task<List<Contact>> GetContactAsync() {
        return await _contactlistCollection.Find(new BsonDocument()).ToListAsync();
    }


    public async Task CreateContactAsync(Contact contact) {
        await _contactlistCollection.InsertOneAsync(contact);
        return;
    }

    public async Task AddToContactAsync(string id, string companyIds ) {
        FilterDefinition<Contact> filter = Builders<Contact>.Filter.Eq("Id", id);
        UpdateDefinition<Contact> update = Builders<Contact>.Update.AddToSet<string>("CompanyIds", companyIds);
        await _contactlistCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteContactAsync(string id) {
        FilterDefinition<Contact> filter = Builders<Contact>.Filter.Eq("Id", id);
        await _contactlistCollection.DeleteOneAsync(filter);
        return;
    }



}
