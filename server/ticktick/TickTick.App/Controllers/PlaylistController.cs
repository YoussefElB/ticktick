using Microsoft.AspNetCore.Mvc;
using TickTick.App.Dtos;
using TickTick.App.Services;
using TickTick.Models.Models;
using TickTick.Repositories.Repositories;

namespace TickTick.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly IRepository<Playlist> _repo;
        public PlaylistController(IRepository<Playlist> repo)
        {
            _repo = repo;
        }

        // GET: PlaylistController

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(AddPlaylistDto), 200)]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        // GET: PlaylistController/Details/5


        // GET: PlaylistController/Create


        // POST: PlaylistController/Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(AddPlaylistDto), 200)]
        public IActionResult Post([FromBody] AddPlaylistDto dto)
        {
            Playlist toAdd = new Playlist(dto.Title, dto.Description, dto.Items);
            return Ok(toAdd);
        }

        // GET: PlaylistController/Edit/5

        // POST: PlaylistController/Edit/5

        // GET: PlaylistController/Delete/5

        // POST: PlaylistController/Delete/5
    }
}
