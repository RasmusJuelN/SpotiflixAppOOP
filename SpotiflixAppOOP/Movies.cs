using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiflixAppOOP
{
    // Movies class Inherits from Content Class to get its properties
    internal class Movies : Content
    {
        public Genre Genre { get; set; }
    }
}
