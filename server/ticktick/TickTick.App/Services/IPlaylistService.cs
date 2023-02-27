using TickTick.App.Dtos;
using TickTick.Models.Models;

namespace TickTick.App.Services
{
    public interface IPlaylistService
    {
        void DeletePerson(Guid id);
        Playlist AddPlaylist(AddPlaylistDto dto);
        Playlist UpdatePlaylist(Guid id, AddPlaylistDto dto);
    }
}
