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

namespace CalendarWPF
{
    /// <summary>
    /// Логика взаимодействия для Choice.xaml
    /// </summary>
    public partial class Choice : UserControl
    {
        private string PathForScreen;
        private string ScreenName;
        public DateTime date;
        

        public Choice(string PathForScreen, string NameThisChoice,DateTime dateTime)
        {
            InitializeComponent();
            this.PathForScreen = PathForScreen;
            this.ScreenName = NameThisChoice;
            UpdateAllInfo(PathForScreen, ScreenName);
        }
        private void UpdateAllInfo(string PathForScreen, string NameThisChoice)
        {
            Act.Text = NameThisChoice;
            Uri absolute = new Uri($"Res/{PathForScreen}", UriKind.Relative);
            NameScreen.Source = new BitmapImage(absolute);
        }
    }
}
