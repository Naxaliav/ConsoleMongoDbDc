var client = new MongoClient(Environment.GetEnvironmentVariable("Connection_String"));
var database = client.GetDatabase(Environment.GetEnvironmentVariable("Database"));

var usersCollection = database.GetCollection<User>("Users");
usersCollection.InsertOne(new User("John", "Snow"));

var user = usersCollection.Find(user => user.FirstName == "John").FirstOrDefault();
Console.WriteLine(user);

record User(  
    string FirstName,
    string LastName)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
