namespace SpotiflixAppOOP
{

    //Content class (parent)
    internal class Content
    {


        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int PlayTime { get; set; }
        public string? StreamingService { get; set; }
    }
    enum Genre { Action = 1, Fantasy, SciFi, Drama, Comedy, Thriller }
    enum MusicGenre { Rap = 1, Pop, Rock, Country, Classic, Dance }


}
