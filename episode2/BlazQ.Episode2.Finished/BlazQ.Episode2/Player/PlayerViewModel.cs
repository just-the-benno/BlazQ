using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Episode2.Player
{
    public class PlayerViewModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String AvatarUrl { get; set; }

    }
}
