namespace SpotiflixAppOOP
{
    //Music class inherits from Content Class, and with fields of its own
    internal class Music : Content
    {
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public MusicGenre MusicGenre { get; set; }
    }
}

