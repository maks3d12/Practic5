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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        DateTime dateTimeInChoice; // дата которая будет передаваться при нажатии соотетствующей кнопки

        public MainPage( )
        {
            InitializeComponent();
            MDatepicker.Text = Convert.ToString(DateTime.Now);
            Update_Wrap_Content();

        }
        public void Update_Wrap_Content() // общее обновление страницы wrappanel
        {
           Wrappanel.Children.Clear();
           DateTime? datetime = MDatepicker.SelectedDate;
           int days_in_month = System.DateTime.DaysInMonth(datetime.Value.Year, datetime.Value.Month);
           for (int i = 1; i <=  days_in_month; i++)
            {
                dateTimeInChoice = new DateTime(datetime.Value.Year, datetime.Value.Month, i);
                DayControl day = new DayControl(dateTimeInChoice);
                day.DayCalendar.Text = i.ToString();
                Wrappanel.Children.Add(day);
            }
        }

        private void last_m_Click(object sender, RoutedEventArgs e)
        {

            MDatepicker.Text = Convert.ToString(Convert.ToDateTime(MDatepicker.Text).AddMonths(-1));
            Update_Wrap_Content();
        }

        private void Next_m_Click(object sender, RoutedEventArgs e)
        {
            MDatepicker.Text = Convert.ToString(Convert.ToDateTime(MDatepicker.Text).AddMonths(1));
            Update_Wrap_Content();
        }
    }
}

