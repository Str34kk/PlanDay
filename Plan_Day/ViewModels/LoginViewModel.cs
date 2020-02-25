using Plan_Day.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plan_Day.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices apiServices = new ApiServices();
        public string Username { get; set; }

        public string Password { get; set; }

        public string Content { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var Content = await apiServices.LoginAsync(Username, Password);
                });
            }
        }
    }
}