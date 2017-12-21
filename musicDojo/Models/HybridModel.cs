using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicDojo.Models
{
    public class HybridModel
    {
        public Song songModel { get; set; }
        public IEnumerable<Song> songs { get; set; }
    }
}
