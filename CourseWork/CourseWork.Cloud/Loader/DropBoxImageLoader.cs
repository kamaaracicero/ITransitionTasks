using Dropbox.Api;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Cloud.Loader
{
    public class DropBoxImageLoader
    {
        public DropBoxImageLoader(string token)
        {
            Token = token;
        }

        public string Token { get; }

        public async Task<string> LoadImage(string imageName)
        {
            using (var dpx = new DropboxClient(Token))
            {
                var list = await dpx.Files.ListFolderAsync(string.Empty);
                foreach (var item in list.Entries.Where(i => i.IsFile))
                {
                    System.Console.WriteLine(item.PreviewUrl);
                }
            }

            return null;
        }
    }
}
