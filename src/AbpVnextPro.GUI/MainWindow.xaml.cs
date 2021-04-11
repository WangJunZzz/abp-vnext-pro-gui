using AbpVnextPro.GUI.ApplicationService.Generates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AbpVnextPro.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GenerateAppService _generateAppService;

        public MainWindow(GenerateAppService generateAppService)
        {
            InitializeComponent();
            _generateAppService = generateAppService;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            this.Logs.Items.Add($"{DateTime.Now.ToLongDateString()}:解决方案名称：CompanyName.ProjectName");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
             await _generateAppService.GenerateSourceAsync();
            if (string.IsNullOrWhiteSpace(this.CompanyName.Text))
            {
                this.Logs.Items.Add("请输入CompanyName");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.ProjectName.Text))
            {
                this.Logs.Items.Add("ProjectName");
                return;
            }

        }
    }
}
