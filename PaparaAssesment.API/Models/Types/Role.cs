﻿using System.ComponentModel.DataAnnotations;

namespace PaparaAssesment.API.Models.Types
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
