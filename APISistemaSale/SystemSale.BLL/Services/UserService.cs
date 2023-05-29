using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemSale.BLL.Services.Contract;
using SystemSale.DAL.Repository.Contract;
using SystemSale.DTO;
using SystemSale.Model;

namespace SystemSale.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            try
            {
                var userCreate = await _repository.Create(_mapper.Map<User>(userDTO));
                if (userCreate.IdUser == 0)
                    throw new TaskCanceledException("Não foi possível criar usuário");

                var query = await _repository.GetAll(u => u.IdUser == userDTO.IdUser);
                userCreate = query.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<UserDTO>(userCreate);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var userFound = await _repository.Get(u => u.IdUser == id);

                if (userFound == null)
                    throw new TaskCanceledException("O usuário não existe");

                bool response = await _repository.Delete(userFound);

                if (!response)
                    throw new TaskCanceledException("Não foi possível deletar usuário " + userFound.NameFull);

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserDTO>> List()
        {
            try
            {
                var queryUser = await _repository.GetAll();
                var listUsers = queryUser.Include(rol => rol.IdRolNavigation).ToList();

                return _mapper.Map<List<UserDTO>>(listUsers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(UserDTO userDTO)
        {
            try
            {
                var userModelo = _mapper.Map<User>(userDTO);
                var userFound = await _repository.Get(u => u.IdUser == userDTO.IdUser);
                if (userFound != null)
                  throw new TaskCanceledException("Usuário informado não existe.");

                userFound.NameFull= userDTO.NameFull;
                userFound.Email = userDTO.Email;
                userFound.IdRol = userDTO.IdRol;
                userFound.Password = userDTO.Password;
                userFound.IsActivo = Convert.ToBoolean(userDTO.IsActivo);

                bool response = await _repository.Update(userFound);

                if(!response)
                    throw new TaskCanceledException("Não foi possível editar usuário " + userFound.NameFull);

                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SessionDTO> validateCredentials(string email, string password)
        {
            try
            {

                var queryUser = await _repository.GetAll(u => u.Email == email && u.Password == password && u.IsActivo == true);

                if (queryUser.FirstOrDefault() == null)
                    throw new TaskCanceledException("Usuário informado não existe.");

                User user = queryUser.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<SessionDTO>(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
