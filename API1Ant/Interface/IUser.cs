using API1Ant.ActionClass.Account;
using API1Ant.ActionClass.HelperClass.DTO;
using Microsoft.Identity.Client;

namespace API1Ant.Interface
{
    public interface IUser
    {
        public List<AccountDTO> GetUsers();
        public List<AccountDTO> GetUser(string phone);
        public List<string> AddAccount(AccountCreate account);
        public List<string> UpdateUser(string phone, AccountDTO user);
        public List<string> DeleteUser(long id);
    }
}
