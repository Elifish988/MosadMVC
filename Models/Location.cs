﻿using System.ComponentModel.DataAnnotations;

namespace MosadMVC.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Location() { }

    }
}
