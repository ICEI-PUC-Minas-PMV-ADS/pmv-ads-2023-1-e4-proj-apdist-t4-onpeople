namespace OnPeople.API.Controllers.Uploads
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
    
        public UploadService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public void DeleteImageUpload(int contaId, Boolean Master, string imageName, string destiny)
        {
            if (!string.IsNullOrEmpty(imageName)) {
                var pathImage = Path.Combine(_hostEnvironment.ContentRootPath, @$"Resources/{destiny}", imageName);
                
                if (File.Exists(pathImage)) {
                    File.Delete(pathImage);
                }
            };
        }

        public async Task<string> SaveImageUpload(int contaId, Boolean Master, IFormFile imageNameUser, string destiny)
        {
            string imageNameNew = new String(Path
            .GetFileNameWithoutExtension(imageNameUser.FileName)
            .Take(15)
            .ToArray()
            ).Replace(' ', '-');

            imageNameNew = $"{imageNameNew}{DateTime.UtcNow:yymmssfff}{Path.GetExtension(imageNameUser.FileName)}";
            
            var pathImage = Path.Combine(_hostEnvironment.ContentRootPath, @$"Resources/{destiny}", imageNameNew);

            using (var fileStream = new FileStream(pathImage, FileMode.Create)) {
                await imageNameUser.CopyToAsync(fileStream);
            };

            return imageNameNew;
        }
    }
}