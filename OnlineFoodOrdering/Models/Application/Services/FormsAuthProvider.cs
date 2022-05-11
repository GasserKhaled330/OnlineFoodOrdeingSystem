using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Infrastructure;
using System.Linq;
using System.Web.Security;

namespace OnlineFoodOrdering.Models.Application.Services
{
    public class FormsAuthProvider : IAuthProvider
    {
        private ApplicationDbContext _appDbContext;

        public FormsAuthProvider()
        {
            _appDbContext = new ApplicationDbContext();
        }
        public bool ValidateUser(string userName, string userPassword)
        {
            var userData = _appDbContext.UserAccounts.Where(user => user.UserName.ToLower() ==
                     userName.ToLower() && user.UserPassword == userPassword);
            if(userData.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Authenticate(string username, string password)
        {
            bool result = ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}