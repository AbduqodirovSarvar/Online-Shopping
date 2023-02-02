using Shop.Domain.Abstracts;
using Shop.Domain.Enums;

namespace Shop.Domain.Entities
{
    public class User : Auditable
    {
        public User()
        { 
            Contracts = new HashSet<Contract>();
        }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime JoinedDate { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }
}
