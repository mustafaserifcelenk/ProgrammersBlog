using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Shared.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Filters
{
    // Sunucu tarafında bir hata alırsak bu sınıf handle edicek hatayı
    public class MvcExceptionFilter:IExceptionFilter
    {
        // Hangi ortamda çalıştığımızı bilmemizi sağlıyor
        private readonly IHostEnvironment _environment;
        // 
        private readonly IModelMetadataProvider _metadataProvider;

        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
        }

        // Hata üzerindeyiz
        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment()) // Ürün aşamasında bu IsProduction olmalı
            {
                // Hata ele alındı demek
                context.ExceptionHandled = true;

                // Message tek olsa burada böyle tanımlardık
                var mvcErrorModel = new MvcErrorModel();
                //{
                //    Message =
                //        $"Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürede çözeceğiz."
                //};

                //ViewResult result; Resultı case içinde tanımlamak için


                switch (context.Exception)
                {
                    case SqlNullValueException:
                        mvcErrorModel.Message =
                            $"Üzgünüz, işleminiz sırasında beklenmedik bir veritabanı hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        break;
                    case NullReferenceException:
                        mvcErrorModel.Message =
                            $"Üzgünüz, işleminiz sırasında beklenmedik bir null hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        // result = new ViewResult { ViewName = "Error2" };
                        break;
                    default:
                        mvcErrorModel.Message =
                            $"Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürede çözeceğiz.";
                        break;
                }
                // Hata durumununda dönülecek view
                var result = new ViewResult {ViewName = "Error"};
                result.StatusCode = 500;
                // ViewData'ya gerekli modelstatei aktarma, bu modelstate bizim mvcErrorModeli taşıyacak?
                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                // ViewData'ya MvcErrorModel'i de gönderiyoruz
                result.ViewData.Add("MvcErrorModel",mvcErrorModel);
                // Hata'nın doğası gereği olaya ortadan dahil olduğumuz için View döndürme işlemi, view'ın adım adım oluşturulması şeklinde gerçekleşiyor
                context.Result = result;
            }
        }
    }
}
