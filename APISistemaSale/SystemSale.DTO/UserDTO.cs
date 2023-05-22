namespace SystemSale.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        public string? NameFull { get; set; }

        public string? Email { get; set; }

        public int? IdRol { get; set; }

        public string? RolDescription { get; set; }

        public string? Password { get; set; }

        public int? IsActivo { get; set; }
    }
}
