namespace OnPeople.Application.Dtos.Users
{
    public class UserRegisterDto
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NomeCompleto { get; set; } 
        public string Visao { get; set; }
         public DateTime DataCadastro { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Master { get; set; }
        public Boolean Gold { get; set; }
        public Boolean Bronze { get; set; }
        public Boolean Ativa { get; set; }

    }
}