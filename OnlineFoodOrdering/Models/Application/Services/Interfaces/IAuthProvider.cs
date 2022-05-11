using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Services.Interfaces
{
    public interface IAuthProvider
    {
        bool ValidateUser(string userName, string userPassword);
        bool Authenticate(string username, string password);

    }
}
