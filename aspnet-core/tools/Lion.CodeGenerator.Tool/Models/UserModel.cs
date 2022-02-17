using Prism.Mvvm;

namespace Lion.CodeGenerator.Tool.Models
{
    public class UserModel : BindableBase
    {

        private string _tenantName;

        public string TenantName
        {
            get { return _tenantName; }
            set { SetProperty(ref _tenantName, value); }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
}
