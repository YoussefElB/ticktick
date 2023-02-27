using TickTick.App.Dtos;
using TickTick.Models.Models;

namespace TickTick.App.Services
{
    public class PlaylistService : IPlaylistService
    {
        public Playlist AddPlaylist(AddPlaylistDto dto)
        {
            return new Playlist(dto.Title, dto.Description, dto.Items);
        }

        public void DeletePerson(Guid id)
        {
            throw new NotImplementedException();
        }

        public Playlist UpdatePlaylist(Guid id, AddPlaylistDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
