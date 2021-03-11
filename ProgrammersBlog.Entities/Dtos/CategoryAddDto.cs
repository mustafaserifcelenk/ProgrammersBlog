using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori adı")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [MaxLength(70, ErrorMessage ="{0} 70 karakterden büyük olamaz.")]
        [MinLength(3, ErrorMessage ="{0, {1} karakterden az olamaz.")]
        public string Name { get; set; }

        [DisplayName("Kategori açıklaması")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden büyük olamaz.")]
        [MinLength(3, ErrorMessage = "{0}, {1} karakterden az olamaz.")]
        public string Description { get; set; }

        [DisplayName("Kategori özel not alanı")]
        [MaxLength(500, ErrorMessage = "{0}, {1} karakterden büyük olamaz.")]
        [MinLength(3, ErrorMessage = "{0}, {1} karakterden az olamaz.")]
        public string Note { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "'{0}' alanı  boş geçilemez.")]
        public bool IsActive { get; set; }
    }
}
