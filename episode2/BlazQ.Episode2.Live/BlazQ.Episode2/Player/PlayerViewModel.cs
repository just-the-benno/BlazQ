using System.ComponentModel.DataAnnotations;

namespace BlazQ.Episode2.Player
{
    public class PlayerViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        [Url]
        public string AvatarUrl { get; set; }
    }
}