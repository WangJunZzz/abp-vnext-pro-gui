using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.CodeGenerator.Tool.System.ViewModels
{
    public class MainHeaderViewModel : BindableBase
    {
        private string _currentUserName;
        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { SetProperty(ref _currentUserName, value); }
        }

        private string _userAvatar;
        public string UserAvatar
        {
            get { return _userAvatar; }
            set { SetProperty(ref _userAvatar, value); }
        }

        public MainHeaderViewModel()
        {
            CurrentUserName = "Admin";
            UserAvatar = "http://120.24.194.14:8012/assets/header.1b5fa5f8.jpg";
        }
    }
}
