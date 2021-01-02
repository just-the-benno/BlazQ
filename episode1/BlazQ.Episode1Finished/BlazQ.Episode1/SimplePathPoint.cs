using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazQ.Episode1
{
    public class SimplePathPoint
    {
        public Guid Id { get; } = Guid.NewGuid();

        [Required]
        [Range(0,100)]
        public Double X { get; set; }

        [Required]
        [Range(0, 100)]
        public Double Y { get; set; }

    }
}
