using System.ComponentModel.DataAnnotations;
using API1Ant.ActionClass.Account;
using API1Ant.ActionClass.HelperClass.DTO;
using API1Ant.Interface;
using API1Ant.Models;

namespace API1Ant.ActionClass
{
    public class UserClass: IUser
    {
        private readonly AntiqueStoreContext _context;
        public UserClass(AntiqueStoreContext context)
        {
            _context = context;
        }

        public List<string> AddAccount(AccountCreate account)
        {
            try
            {
                Client createUser = new Client()
                {
                    Name = account.Name,
                    Phone = account.Password,
                    Email = account.Email,
                };

                _context.Clients.Add(createUser);
                _context.SaveChanges();

                long userId = createUser.Id;

                Results.Created();
                return [$"Пользователь успешно создан Id - {userId}"];
            }
            catch (Exception)
            {
                Results.BadRequest(new List<string> {"Ошибка в выполнении запроса" });
                throw;
            }
        }

        public List<string> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetUser(string phone)
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetUsers()
        {
            try
            {
                var data = _context.Clients.Select(
                    x => new AccountDTO()
                    {
                        Id = x.Id,
                        Name = x.Name + " ",
                        Email = x.Email,
                        Phone = x.Phone,
                    }
                    ).ToList();

                return (List<AccountDTO>)data;
            }
        catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<AccountDTO> UpdateUser(string phone, AccountDTO user)
        {
            throw new NotImplementedException();
        }

        List<string> IUser.UpdateUser(string phone, AccountDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
