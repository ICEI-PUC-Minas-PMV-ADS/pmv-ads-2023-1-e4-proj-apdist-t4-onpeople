using Microsoft.AspNetCore.Identity;

namespace OnPeople.Domain.Models.Users
{
    public class Role : IdentityRole<int>
    {
        public string NomeFuncao { get; set; }
        public IEnumerable<UserRole> UsersRoles { get; set; }
    }
}