using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class TabletData
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tablet Name")]
        public string TabletName { get; set; }

        [Display(Name = "Screen Size")]
        public int ScreenSize { get; set; }

        [Required]
        [Display(Name = "Internal Memory")]
        public string InternalMemory { get; set; }

        [Display(Name = "Camera Pixels")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public int CameraPixels { get; set; }

        [Display(Name = "Battery Name")]
        public string BatteryName { get; set; }


        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}