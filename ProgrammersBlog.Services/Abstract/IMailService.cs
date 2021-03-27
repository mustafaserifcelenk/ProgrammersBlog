using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IMailService
    {
        // Şifremi unuttum, bilgilerim değiştirildi, bildirim gibi genel e-postaları gönderecek
        IResult Send(EmailSendDto emailSendDto); // alper@altu.dev

        // 
        IResult SendContactEmail(EmailSendDto emailSendDto); // alper@altu.dev info@programmersblog.com iletisim@programmersblog.com
    }
}
