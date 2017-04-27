namespace SwitchYourHome.Models.Ads
{
    using Helpers;
    using System.ComponentModel.DataAnnotations;

    public class AdViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        public int Accommodates { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public string Smoking { get; set; }

        public string Childrens { get; set; }

        public string Pets { get; set; }

        public string Description { get; set; }

        [Required]
        public string Available { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        [ImageUrl]
        public string ImageUrl { get; set; }

        public string OwnerId { get; set; }

    }
}