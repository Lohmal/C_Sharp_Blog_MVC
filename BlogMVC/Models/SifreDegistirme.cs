﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class SifreDegistirme
    {
        [Required]
        [DisplayName("Şimdiki şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni şifre")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Şifreniz en az 5 karakter olmalı.")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("NewPassword",ErrorMessage ="Şifreler aynı değil.")]
        public string ConNewPassword { get; set; }
    }
}