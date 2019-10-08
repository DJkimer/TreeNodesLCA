using System.ComponentModel.DataAnnotations.Schema;

namespace TreesAPI.Models
{
    public class Node
    {
        public int Id{get; set;}

        public int Value{get; set;}
        public int? LeftId{get; set;}

        [ForeignKey("LeftId")]
        public Node Left{get; set;}
        public int? RightId{get; set;}

        [ForeignKey("RightId")]
        public Node Right{get; set;}

    }
}