using Prism.Mvvm;

namespace Lion.CodeGenerator.Tool.Models
{
    public class CurrentUserModel : BindableBase
    {
        private string _userName = "admin";

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
    }
}
