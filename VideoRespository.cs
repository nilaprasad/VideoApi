using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using VideoApi;

public class VideoRepository : IVideoRepository
{

  private readonly IVideoContext _context;

  public VideoRepository(IVideoContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Video>> GetAllVideos()
  {
    return await _context.Video.Find(_context => true).ToListAsync();
  }

  public Task<Video> GetVideo(string name)
  {
    FilterDefinition<Video> filter = Builders<Video>.Filter.Eq(m => m.name, name);

    return _context.Video.Find(filter).FirstOrDefaultAsync();
  }

  public async Task Create(Video video)
  {
    await _context.Video.InsertOneAsync(video);
  }

  public async Task<bool> Update(Video video)
  {
    ReplaceOneResult updateResult = await _context.Video.ReplaceOneAsync(filter: g => g._id == video._id, replacement: video);

    return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
  }

  public async Task<bool> Delete(string name)
  {
    FilterDefinition<Video> filter = Builders<Video>.Filter.Eq(m => m.name, name);

    DeleteResult deleteResult = await _context.Video.DeleteOneAsync(filter);

    return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
  }
}