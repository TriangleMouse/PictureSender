using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureSender.DAL.Repositories
{
    public class ImageRepository
    {
        private readonly string imagesFolderPath;

        public ImageRepository()
        {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), "PictureSender",
                "Images");
        }

        /// <inheritdoc/>
        public bool CheckSystemCatalogExists()
        {
            return Directory.Exists(imagesFolderPath);
        }

        public void CreateDerictory()
        {
            if (!CheckSystemCatalogExists())
            {
                Directory.CreateDirectory(imagesFolderPath);
            }
        }

        /// <inheritdoc/>
        public async Task SaveFileToAppData(string fileName, byte[] fileContent)
        {
            await ExecuteAsync(async () => {
                string filePath = Path.Combine(imagesFolderPath, fileName);
                File.WriteAllBytes(filePath, fileContent);
            });
        }

        /// <inheritdoc/>
        public async Task<IList<string>> GetAllFileNames()
        {
            List<string> fileNames = default;

            await ExecuteAsync(async () =>
            {
                fileNames = Directory.GetFiles(imagesFolderPath).Select(Path.GetFileName).ToList();
            });

            return fileNames;
        }


        /// <inheritdoc/>
        public async Task<byte[]> GetFileContentByName(string fileName)
        {
            byte[] fileContent = default;
            await ExecuteAsync(async () =>
            {
                string filePath = Path.Combine(imagesFolderPath, fileName);
                fileContent = File.ReadAllBytes(filePath);
            });

            return fileContent;
        }

        /// <inheritdoc/>
        public void DeleteAllFiles()
        {
            try
            {
                Directory.Delete(imagesFolderPath, true);
            }
            catch
            {
                // исключение пустое, потому что оно возникает только тогда, когда файл из этой папки открыт, но при этом файл удаляется 
            }
        }
    }
}
