using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiflixAppOOP
{
    // Series Class, inherits from Content Class, and has fields of its own
    internal class Series : Content
    {
        public Genre Genre { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }
    }
}
