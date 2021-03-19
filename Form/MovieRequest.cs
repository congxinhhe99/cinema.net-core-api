using cinema_core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cinema_core.Form
{
    public class MovieRequest
    {
        [Required]
        public string Directors { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Poster { get; set; }
        [Required]
        public string Runtime { get; set; }
        [Required]
        public string ReleasedAt { get; set; }
     
        [Required]

        public string Imdb { get; set; }

        [Required]
        public List<int> ScreenTypeIds { get; set; }

        [Required]
        public string EndAt { get; set; }
        public string[] Wallpapers { get; set; }
        public string Trailer { get; set; }
        public string Story { get; set; }

        [Required]
        public int RateId { get; set; }
    }
}
