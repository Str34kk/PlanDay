using Plan_Day.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plan_Day.ViewModels
{
    public class RegisterViewModel
    {
        private ApiServices apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message;

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    if (isSuccess)
                    {
                        Message = "registered";
                    }
                    else
                    {
                        Message = "smth went wrong";
                    }
                });
            }
        }
    }
}