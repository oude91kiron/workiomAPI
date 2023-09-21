namespace workiomAPI.Models;

/**
* Class to config Mongodb Connection
*/
public class MongoDBSettings {

    public string ConnectionURI { get; set;} = null!;
    public string DatabaseName { get; set;} = null!;
    public string CollectionName1 { get; set;} = null!;
    public string CollectionName2 { get; set;} = null!;
}
