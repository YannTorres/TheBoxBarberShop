using TheBoxBarberShop.Domain.Enums;

namespace TheBoxBarberShop.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = Roles.CLIENT;
    public DateTime CreatedAt { get; set; }
}
