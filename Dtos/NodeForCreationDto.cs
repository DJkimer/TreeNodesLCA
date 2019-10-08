using System;
using System.ComponentModel.DataAnnotations;

namespace TreesAPI.Dtos
{
    public class NodeForCreationDto
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Value{get; set;}
    }
}