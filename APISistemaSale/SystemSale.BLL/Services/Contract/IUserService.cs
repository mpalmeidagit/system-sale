using SystemSale.DTO;

namespace SystemSale.BLL.Services.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> List();
        Task<SessionDTO> ValidateCredentials(string email, string password);
        Task<UserDTO> Create(UserDTO userDTO);
        Task<bool> Update(UserDTO userDTO);
        Task<bool> Delete(int id);
    }
}
