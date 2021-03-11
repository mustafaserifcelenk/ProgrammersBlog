using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult // <T> : Veri bir user, category vs olabilir o yüzden generic olmalı
                                                  // out : Bir kategoriyi tek başına da taşımak isteyebiliriz, ya da bu kategoriyi bir IList veya bir IEnumarable olarak da taşımak isteyebiliriz,                  her işlem için farklı property tanımlamak yerine, bu şekilde tanımlayarak tek bir property içerisinde ister bir liste, ister tek bir                    entity taşıyabiliyor olacağız
    {
        public T Data { get; } // ister bir category ister bir category list atama örneği: new DataResult<Category>(ResultStatus.Success, category); // service katmanında işlediğimiz kategoriyi MVC katmanına göndermek istiyoruz ve eğer kategori bize başarılı bir şekilde geldiyse de, Success'i ve Category değerini gönderiyoruz
        // new DataResult<IList<Category>>(ResultStatus.Success, categoryList); 
    }
}
