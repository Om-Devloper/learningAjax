using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLibrary.Interface
{
    public interface IEmailService
    {
        Task SendTestEmail();

        //Task SendEmailForEmailConfirmation();

        //Task SendEmailForForgotPassword();


    }
}
