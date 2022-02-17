using Lion.CodeGenerator.Tool.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;

namespace Lion.CodeGenerator.Tool.ViewModels
{
    public class LoginWinViewModel : BindableBase
    {
        public ICommand LoginCommand { get; set; }
        public UserModel UserModel { get; set; } = new UserModel();

        public LoginWinViewModel()
        {
            LoginCommand = new DelegateCommand<object>(OnLogin);
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _loadingMessage;

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetProperty(ref _loadingMessage, value); }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private void OnLogin(object obj)
        {
            if (string.IsNullOrEmpty(UserModel.TenantName))
            {
                this.ErrorMessage = "请输入租户";
                return;
            }

            if (string.IsNullOrEmpty(UserModel.UserName))
            {
                this.ErrorMessage = "请输入用户名";
                return;
            }

            if (string.IsNullOrEmpty(UserModel.Password))
            {
                this.ErrorMessage = "请输入密码";
                return;
            }

            this.LoadingMessage = "正在登录....";
            this.IsLoading = true;

            try
            {


            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
