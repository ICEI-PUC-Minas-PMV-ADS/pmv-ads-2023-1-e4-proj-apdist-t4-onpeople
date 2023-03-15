namespace OnPeople.Application.Dtos.Users
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public string Visao { get; set; }
        public string Foto { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }
        public Boolean Master { get; set; }

    }
}