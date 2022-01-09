var client = new MongoClient(Environment.GetEnvironmentVariable("Connection_String"));
var database = client.GetDatabase(Environment.GetEnvironmentVariable("Database"));

var collection = database.GetCollection<User>("Users");
collection.InsertOne(new User("John", "Snow"));

var user = collection.Find(user => user.FirstName == "John").FirstOrDefault();
Console.WriteLine(user);

record User(  
    string FirstName,
    string LastName)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
