﻿using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        //public ResultStatus ResultStatus { get; set; } ResultStatus her sınıfta ortak olacağından bunu sharede koyacaz
        //public override ResultStatus ResultStatus { get; set; } = ResultStatus.Success;
        public int? CategoryId { get; set; }
    }
}
