using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoApi
{
  public interface IVideoRepository
  {
    Task<IEnumerable<Video>> GetAllVideos();
    Task<Video> GetVideo(string name);
    Task Create(Video video);
    Task<bool> Update(Video video);
    Task<bool> Delete(string name);
  }
}