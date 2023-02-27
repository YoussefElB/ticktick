using TickTick.Models.Contracts;

namespace TickTick.Models.Models
{
    internal class Song : BaseEntity, IPlaylistItem
    {
        public TimeSpan? Duration { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public uint SequenceNumber { get; set; }
    }
}
