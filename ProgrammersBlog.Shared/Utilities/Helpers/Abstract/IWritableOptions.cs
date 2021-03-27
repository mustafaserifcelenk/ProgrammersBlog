using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ProgrammersBlog.Shared.Utilities.Helpers.Abstract
{
    // out T burada bizim bu T değerini referans üzerinden alıp kullanacağımızı söyler
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        // Appsettings içindeki değerleri güncellemeyi sağlayacak metot
        // Action : predicateler gibidir, lambdayı kullanarak belirli değerleri alacak ve onları değiştirebileceğiz
        void Update(Action<T> applyChanges); // (x=>x.Header = "Yeni Başlık") x=>{x.Header = "Yeni Başlık";x.Content="Yeni İçerik"}
    }
}
