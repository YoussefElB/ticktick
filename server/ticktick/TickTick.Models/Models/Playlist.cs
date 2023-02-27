namespace TickTick.Models.Models
{
    public class Playlist : BaseAuditableEntity
    {
        public Guid PublicId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<PlaylistItem>? Items { get; set; }

        public void CreatePublicId()
        {
            PublicId = Guid.NewGuid();
        }

        public Playlist(string? title, string? description, IList<PlaylistItem>? items)
        {
            CreatePublicId();
            Title = title;
            Description = description;
            Items = items;
        }
        public Playlist()
        {
            CreatePublicId();
        }
    }
}
