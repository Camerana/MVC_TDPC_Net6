namespace MVC_TDPC_Net6.Models
{
    public class MusicModel
    {
        public List<SongAndArtistModel> Songs { get; set; } = new List<SongAndArtistModel>();

        public class SongAndArtistModel
        {
            public string? SongName { get; set; }
            public string? ArtistName { get; set; }
        }
    }
}
