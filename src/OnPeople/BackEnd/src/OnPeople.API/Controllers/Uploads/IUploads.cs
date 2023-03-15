namespace OnPeople.API.Controllers.Uploads
{
    public interface IUploads
    {
        void DeleteImageUpload(int contaId, Boolean Master, string nomeImagem, string destino);
        Task<string> SaveImageUpload(int contaId, Boolean Master, IFormFile arquivoImagem, string destino);
    }

}