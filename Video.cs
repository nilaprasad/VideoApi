using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VideoApi
{
  public class Video
  {
    [BsonId]
    public ObjectId _id { get; set; }

    public string name { get; set; }

    public string link { get; set; }

    public string imageUrl { get; set; }

    public string numberOfViews { get; set; }

    public Channel channel { get; set; }
  }

  public class Channel
  {
    public string name { get; set; }

    public string profileImageUrl { get; set; }

    public string numberOfSubscribers { get; set; }
  }
}