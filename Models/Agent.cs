﻿using System.ComponentModel.DataAnnotations;

namespace MosadMVC.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        public string photo_url { get; set; }
        public string Name { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public StatusAgent? Status { get; set; }
    }
}

