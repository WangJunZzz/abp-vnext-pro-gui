using AbpVnextPro.GUI.ApplicationService.Generates;
using AbpVnextPro.GUI.Domain;
using AbpVnextPro.GUI.Domain.Exceptions;
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
            this.Logs.Text += $"{DateTime.Now.ToString() } 解决方案名称：CompanyName.ProjectName \r\n";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(this.CompanyName.Text))
                //{
                //    this.Logs.Items.Add("请输入CompanyName");
                //    return;
                //}
                //if (string.IsNullOrWhiteSpace(this.ProjectName.Text))
                //{
                //    this.Logs.Items.Add("ProjectName");
                //    return;
                //}
                
                this.Logs.Text += $"{DateTime.Now.ToString() } 开始下载 Abp-Vnext-Pro....... \r\n";
                var sourcePath = await _generateAppService.DownloadSourceAsync();
                this.Logs.Text += $"{DateTime.Now.ToString() } Abp-Vnext-Pro下载完成. \r\n";

                this.Logs.Text += $"{DateTime.Now.ToString() } 开始解压 Abp-Vnext-Pro....... \r\n";
                var zipPath= _generateAppService.ExtractZips(sourcePath);
                this.Logs.Text += $"{DateTime.Now.ToString() } 解压 Abp-Vnext-Pro 完成. \r\n";

                this.Logs.Text += $"{DateTime.Now.ToString() } 开始生成 Abp-Vnext-Pro 模板....... \r\n";
                _generateAppService.GenerateTemplate(zipPath, this.CompanyName.Text.Trim(), this.ProjectName.Text.Trim());
                this.Logs.Text += $"{DateTime.Now.ToString() } Abp-Vnext-Pro 模板生成成功. \r\n";

            }
            catch (Exception ex)
            {
                this.Logs.Text += ex.Message;
            }
        }
    }
}
