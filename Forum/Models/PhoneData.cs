using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PhoneData
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phone Name")]
        public string PhoneName { get; set; }

        [Display(Name = "Battery Name")]
        public string BatteryName { get; set; }

        [Display(Name = "RAM Memory")]
        public int MemoryRam { get; set; }

        [Display(Name = "Camera Pixels")]
        public int CameraPixels { get; set; }


        public virtual Post Post { get; set; }
        public int PostId { get; set; }



    }
}