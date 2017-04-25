﻿namespace SwitchYourHome.Data
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Accommodates { get; set; }

        [Required]
        [Range (1, 20)]
        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public string Smoking { get; set; }

        public string Childrens { get; set; }

        public string Pets { get; set; }

        public string Description { get; set; }

        [Required]
        public string Available { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}