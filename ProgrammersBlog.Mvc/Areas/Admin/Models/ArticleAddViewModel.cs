﻿using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class ArticleAddViewModel
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanu {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanu {1} karakterden küçük olmamalıdır.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MinLength(20, ErrorMessage = "{0} alanu {1} karakterden küçük olmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Küçük Resim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public IFormFile ThumbnailFile { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanu {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanu {1} karakterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Makale Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanu {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanu {1} karakterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }

        [DisplayName("Makale Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} alanu {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanu {1} karakterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")] //Dropdownlistten alıcak ama biz orada listeyi gösterirken arka planda id bilgisini tutuyor olacağız
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int CategoryId { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "'{0}' alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }

        public IList<Category> Categories { get; set; }

    }
}
