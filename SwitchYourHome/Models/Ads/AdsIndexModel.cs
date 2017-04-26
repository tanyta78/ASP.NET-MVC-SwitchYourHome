namespace SwitchYourHome.Models.Ads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AdsIndexModel
    {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Location { get; set; }

            public int Accommodates { get; set; }

            public int Bedrooms { get; set; }

            public int Bathrooms { get; set; }

            public string Smoking { get; set; }

            public string Childrens { get; set; }

            public string Pets { get; set; }

            public string Available { get; set; }

            public string ImageUrl { get; set; }

            public string OwnerId { get; set; }

        }
    }
