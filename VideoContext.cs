using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace VideoApi
{
  public class VideoContext : IVideoContext
  {
    private readonly IMongoDatabase _db;

    public VideoContext(IOptions<Settings> options)
    {
      var client = new MongoClient(options.Value.ConnectionString);
      _db = client.GetDatabase(options.Value.Database);
    }

    public IMongoCollection<Video> Video => _db.GetCollection<Video>("Videos");
  }
}