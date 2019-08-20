using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace VideoApi.Controllers
{
  [Produces("application/json")]
  [Route("api/Video")]

  public class VideoController : Controller
  {
    private readonly IVideoRepository _videoRepository;

    public VideoController(IVideoRepository videoRepository)
    {
      _videoRepository = videoRepository;
    }

    //GET: api/Video
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return new ObjectResult(await _videoRepository.GetAllVideos());
    }

    //GET: api/Video/name
    [HttpGet("{name}", Name = "Get")]
    public async Task<IActionResult> Get(string name)
    {
      var video = await _videoRepository.GetVideo(name);

      if (video == null)
        return new NotFoundResult();

      return new ObjectResult(video);
    }

    //POST: api/Video
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Video video)
    {
      await _videoRepository.Create(video);
      return new OkObjectResult(video);
    }

    //PUT: api/Video
    [HttpPut("{name}")]
    public async Task<IActionResult> Put(string name, [FromBody] Video video)
    {
      var videoFromDb = await _videoRepository.GetVideo(name);

      if (videoFromDb == null)
        return new NotFoundResult();
      video._id = videoFromDb._id;

      await _videoRepository.Update(video);

      return new OkObjectResult(video);
    }

    //DELETE: api/ApiWithActions
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
      var videoFromDb = await _videoRepository.GetVideo(name);

      if (videoFromDb == null)
        return new NotFoundResult();

      await _videoRepository.Delete(name);

      return new OkResult();
    }
  }
}