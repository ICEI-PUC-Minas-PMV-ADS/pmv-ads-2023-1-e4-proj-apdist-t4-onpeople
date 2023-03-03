namespace OnPeople.API.Models.Empresas
{
    public class Empresa
    {
        public int EmpresaId { get; set; }  
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string SiglaEmpresa { get; set; }
        public Boolean Ativa { get; set; }
        public string DataCadastro { get; set; }
        public string DataDesativacao { get; set; }
        public Boolean  Filial { get; set; }
        public int MatrizId { get; set; }
    }
}