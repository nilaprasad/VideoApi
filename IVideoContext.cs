using MongoDB.Driver;

namespace VideoApi
{

  public interface IVideoContext
  {
    IMongoCollection<Video> Video { get; }
  }
}