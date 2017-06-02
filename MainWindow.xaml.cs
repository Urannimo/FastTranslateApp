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
using System.Net;
using System.IO;

namespace TranslateAppOne
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void translateButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(resultTextBox.Document.ContentStart, resultTextBox.Document.ContentEnd);
            textRange.Text = getLanguage(sourceTextBox.Text);
        }

        private string getLanguage(string baseText)
        {
            try
            {
                HttpWebRequest newReq = WebRequest.CreateHttp(appSettings.apiBaseDetect + appSettings.getApikey() + "&text=" + baseText);
                return sendRequest(newReq);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private string sendRequest(HttpWebRequest req)
        {
            req.Method = "GET";
            
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = new NetworkCredential("grinkoym", "gfm015ze0");
            req.Proxy = proxy;
            req.PreAuthenticate = true;

            var response = (HttpWebResponse)req.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
