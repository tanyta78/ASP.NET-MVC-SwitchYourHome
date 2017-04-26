﻿namespace SwitchYourHome.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ImageUrlAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var imageUrl = value as string;
            if (imageUrl == null)
            {
                return true;
            }

            return imageUrl.EndsWith(".jpg")
                 || imageUrl.EndsWith(".png")
                 || imageUrl.EndsWith(".jpeg")
                 || imageUrl.EndsWith(".gif");


        }
    }
}