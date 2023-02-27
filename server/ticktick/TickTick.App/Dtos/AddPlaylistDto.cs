using TickTick.Models.Models;

namespace TickTick.App.Dtos
{
    public class AddPlaylistDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<PlaylistItem>? Items { get; set; }
    }
}
