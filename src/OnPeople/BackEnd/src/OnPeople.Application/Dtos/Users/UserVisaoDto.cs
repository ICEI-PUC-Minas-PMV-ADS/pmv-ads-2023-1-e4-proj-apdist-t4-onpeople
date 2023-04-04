namespace OnPeople.Application.Dtos.Users
{
    public class UserVisaoDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NomeCompleto { get; set; } 
        public string Email { get; set; }
        public string Visao { get; set; }
        public string Foto { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }
        public Boolean Master { get; set; }
        public Boolean Gold { get; set; }
        public Boolean Bronze { get; set; }
        public int CodEmpresa { get; set; }    
        public string NomeEmpresa { get; set; }
        public int CodCargo { get; set; }
        public int CodDepartamento { get; set; }
        public int CodFuncionario { get; set; }
        public int CodMeta { get; set; }
    }
}