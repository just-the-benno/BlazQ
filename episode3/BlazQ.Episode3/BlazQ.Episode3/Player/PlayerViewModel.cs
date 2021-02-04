using System.ComponentModel.DataAnnotations;

namespace BlazQ.Player
{
    public class PlayerViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required]
        public string AvatarUrl { get; set; }
    }
}