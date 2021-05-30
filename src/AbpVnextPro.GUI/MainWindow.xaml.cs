using AbpVnextPro.GUI.ApplicationService.Generates;
using AbpVnextPro.GUI.Domain;
using AbpVnextPro.GUI.Domain.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
            var defaultSelected = "AbpVnextPro";
            this.Source.Items.Add(defaultSelected);
            this.Source.SelectedItem = defaultSelected;
            this.Logs.Text += $"{DateTime.Now.ToString() } 解决方案名称：CompanyName.ProjectName \r\n";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Logs.Text += $"{DateTime.Now.ToString() } 代码已经生成在 {Directory.GetCurrentDirectory()} \r\n";
                if (string.IsNullOrWhiteSpace(this.CompanyName.Text))
                {
                    this.Logs.Text += $"{DateTime.Now.ToString() } 请输入CompanyName....... \r\n";

                    return;
                }
                if (string.IsNullOrWhiteSpace(this.ProjectName.Text))
                {
                    this.Logs.Text += $"{DateTime.Now.ToString() } 请输入ProjectName....... \r\n";
                    return;
                }
         

                this.Logs.Text += $"{DateTime.Now.ToString() } 开始下载 {this.Source.Text}....... \r\n";
                var sourcePath = await _generateAppService.DownloadSourceAsync(this.Source.Text);
                this.Logs.Text += $"{DateTime.Now.ToString() } Abp-Vnext-Pro下载完成. \r\n";

                this.Logs.Text += $"{DateTime.Now.ToString() } 开始解压 {this.Source.Text}....... \r\n";
                var zipPath = _generateAppService.ExtractZips(sourcePath, this.CompanyName.Text.Trim(), this.ProjectName.Text.Trim());
                this.Logs.Text += $"{DateTime.Now.ToString() } 解压 {this.Source.Text} 完成. \r\n";

                this.Logs.Text += $"{DateTime.Now.ToString() } 开始生成 {this.Source.Text} 模板....... \r\n";
                _generateAppService.GenerateTemplate(zipPath, this.CompanyName.Text.Trim(), this.ProjectName.Text.Trim());
                this.Logs.Text += $"{DateTime.Now.ToString() } {this.Source.Text} 模板生成成功. \r\n";
                this.Logs.Text+= $"{DateTime.Now.ToString() } 代码已经生成在 {Directory.GetCurrentDirectory()}\\code下 \r\n";

            }
            catch (Exception ex)
            {
                this.Logs.Text += ex.Message;
            }
        }
    }
}
