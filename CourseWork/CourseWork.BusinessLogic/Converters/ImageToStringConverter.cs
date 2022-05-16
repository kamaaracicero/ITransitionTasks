using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace CourseWork.BusinessLogic.Converters
{
    internal class ImageToStringConverter : IConverter<IFormFile, string>
    {
        public string Convert(IFormFile data)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                data.CopyTo(stream);

                return System.Convert.ToBase64String(stream.ToArray());
            }
        }

        public async Task<string> ConvertAsync(IFormFile data)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                await data.CopyToAsync(stream);

                return System.Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
