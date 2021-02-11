using System;
using System.Collections.Generic;
using System.Text;
using WebNothing.Application.ViewModels;

namespace WebNothing.Application.Interfaces
{
    public interface IAuthService
    {
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);

        bool IsAuthenticated();

        string EncryptPassword(string password);
    }
}
