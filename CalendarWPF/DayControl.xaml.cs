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
    
    public partial class DayControl : UserControl
    {
        public DateTime SelectedDate;
        public DayControl(DateTime dateTime)
        {
            InitializeComponent();
            MouseLeftButtonDown += CalendarItemUserControl_MouseLeftButtonDown;
            SelectedDate = dateTime;
        }
        private void CalendarItemUserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void SpisokPicture_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Content = new PageWithChoice(SelectedDate);
        }
    }
}
