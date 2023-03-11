namespace OnPeople.API.Controllers.Uploads
{
    public interface IUploads
    {
        void DeleteImageUpload(string nomeImagem, string destino);
        Task<string> SaveImageUpload(IFormFile arquivoImagem, string destino);
    }

}