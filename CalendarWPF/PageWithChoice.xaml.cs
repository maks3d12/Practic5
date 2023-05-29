using CalendarWPF.@class;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CalendarWPF
{
    /// <summary>
    /// Логика взаимодействия для PageWithChoice.xaml
    /// </summary>
    public partial class PageWithChoice : Page
    {
        DateTime DT_with_choice;
        
        List<Class_Choice> listforSave = new List<Class_Choice>();
        List<Choice> ListHelper = new List<Choice>();
        public PageWithChoice(DateTime datetime)
        {
            try
            {
                listforSave = Json.ReadFromFile<Class_Choice>("Plan.json");
            }
            catch 
            {

            }
            DT_with_choice = datetime;
            InitializeComponent();
            List<Choice> listd = new List<Choice>() {
            new Choice("ThreeDote.png","Прокорстинация",datetime),
            new Choice("homework.jpg","Домашка", datetime),
            new Choice("lapsha.png","Покушать", datetime),
            new Choice("cooking.png","Готовить", datetime),
            new Choice("cleanning.jpg","Уборка", datetime)
            };
            UpdateTextBox(DT_with_choice);
            Updatelist(listd);
        }
        void UpdateTextBox(DateTime datetime) {
            TB_With_date.Text = datetime.ToShortDateString();
        }
        void Updatelist(List<Choice> listd)
        {
            list.Items.Clear();
            list.ItemsSource = listd;
        }

        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            ListHelper.Clear();
            foreach (Choice choice in list.ItemsSource) // заполнение вспомогательного листа
            {
                ListHelper.Add(choice);

            }
            CheckAndDeleteNote();
            AddNewNote();
            Json.MySerialize("Plan.json", listforSave);
        }
        private void AddNewNote()
        {
            bool isAdded = false;
            for (int i = 0; i < ListHelper.Count; i++) // добавление нового класса в лист
            {
                if (ListHelper[i].Check.IsChecked == true)
                {
                    if (listforSave != null)
                    {
                        for (int j = 0; j < listforSave.Count; j++) // проверка на неповтороность добавленного элемента
                        {
                            isAdded = false;
                            if (DT_with_choice.ToShortDateString() == listforSave[j].Date.ToShortDateString())
                            {
                                if (ListHelper[i].Act.Text == listforSave[j].Namescreen)
                                {
                                    isAdded = true;
                                }
                            }
                            if (isAdded)
                            {
                                continue;
                            }

                        }
                    }
                    if (isAdded == false)
                    {
                        listforSave.Add(new Class_Choice(DT_with_choice, ListHelper[i].Act.Text));
                    }

                }
            }
        }
        private void CheckAndDeleteNote()
        {
            if (listforSave != null)
            {


                for (int i = 0; i < listforSave.Count; i++) // удаление всех пользовательских элементов из листа для сохранения у которых была убрана галочка
                {
                    if (listforSave[i].Date.ToShortDateString() == Convert.ToDateTime(TB_With_date.Text).ToShortDateString())
                    {
                        for (int j = 0; j < list.Items.Count; j++)
                        {
                            if (ListHelper[j].Check.IsChecked == false && ListHelper[j].Act.Text == listforSave[i].Namescreen)
                            {
                                listforSave.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }
        
        private void back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).Content = new MainPage();
        }
    }
}
