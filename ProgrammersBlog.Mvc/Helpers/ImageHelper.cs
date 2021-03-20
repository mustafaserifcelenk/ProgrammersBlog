using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Helpers
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            // ~/img/user.Picture
            _wwwroot = _env.WebRootPath;
        }

        public Task<IDataResult<UploadedImageDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName)
        {
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.PictureFile.FileName); // .png, .jpeg olmadan alıyoruz, bunu kullanabilirsin istersen
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            // AlperTunga_587_5_38_12_3_10_2020.png
            string fileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/img", fileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            return fileName; // AlperTunga_587_5_38_12_3_10_2020.png - "~/img/user.Picture"
        }
    }
}
