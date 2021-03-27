﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;

namespace ProgrammersBlog.Services.Concrete
{
    public class MailManager:IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        // Bu bize section içindeki bilgilerin gelmesini sağlar, servicin değil
        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail), //alpertunga004@outlook.com

                // MailAdress gönderilen maili kullanarak 'To' da belirtilen maile mail gönderiyor
                To = { new MailAddress(emailSendDto.Email) }, //alper@altu.dev
                Subject = emailSendDto.Subject, //Şifremi Unuttum // Siparişiniz Başarıyla Kargolandı.
                IsBodyHtml = true,
                Body = emailSendDto.Message // "12345" No'lu siparişiniz kargolanmıştır.
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                // Kendi e-postamız eposta gönderim işlemi için kullanılacak
                // Biri bize e-mail göndermek istediğinde bu emailin bilgileri senderEmail tarafından bizim maile iletilecek biz oradan cevap vereceğiz
                From = new MailAddress(_smtpSettings.SenderEmail), 
                // Bu adrese gönderecek
                To = { new MailAddress("mustafaserifcelenk@gmail.com")}, //info@programmersblog.com
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = $"Gönderen Kişi: {emailSendDto.Name}, Gönderen E-Posta Adresi:{emailSendDto.Email}<br/>{emailSendDto.Message}"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username,_smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }
    }
}