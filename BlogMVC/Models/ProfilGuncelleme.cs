﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class ProfilGuncelleme
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçerli bir email giriniz.")]
        public string Email { get; set; }
    }
}