using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        // Zaten resultlarda resultstatus'lar olacak neden burda da ekledik? Cevap : Viewlarda da Article yanında ResultStatus'a da ihtiyacımız olacak. Success olup olmamasına göre farklı görünümler isteyeceğiz.
        public Article Article { get; set; }
        //public ResultStatus ResultStatus { get; set; }
    }
}
