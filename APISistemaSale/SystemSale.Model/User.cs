namespace SystemSale.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameFull { get; set; }

    public string? Email { get; set; }

    public int? IdRol { get; set; }

    public string? Password { get; set; }

    public bool? IsActivo { get; set; }

    public DateTime? DateRegistration { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
