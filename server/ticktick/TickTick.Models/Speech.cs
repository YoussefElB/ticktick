using TickTick.Models.Contracts;

namespace TickTick.Models
{
    public class Speech : BaseEntity, IPlaylistItem
    {
        public TimeSpan? Duration { get; set; }
        public string? Speaker { get; set; }
        public string Title { get; set; }
        public uint SequenceNumber { get; set; }
    }
}
