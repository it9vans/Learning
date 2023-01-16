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

namespace Main_Project
{
    /// <summary>
    /// Логика взаимодействия для PracticePage.xaml
    /// </summary>
    public partial class PracticePage : Page
    {
        public PracticePage()
        {
            InitializeComponent();
        }

        private void TextBoxExercise_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxExResult_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        short result;

        public string CreatingExercise()
        {
            Random rand = new Random();

            bool predifficult = rand.Next(100) < 50 ? true : false;
            if (predifficult == true)
            {
                short sl_first, sl_second;
                do
                {
                    sl_first = (short)rand.Next(-30, 30);
                    sl_second = (short)rand.Next(-30, 30);

                    if (sl_first > sl_second && sl_first >= 0)
                    {
                        if (sl_second > 0)
                            sl_first = (short)rand.Next(0, sl_second);
                        else
                            sl_first = (short)rand.Next(0, sl_second * -1);
                    }
                    else if (sl_second > sl_first && sl_second >= 0)
                    {
                        sl_first = (short)rand.Next(sl_second, 30);

                    }
                }
                while (sl_first >= 0 && sl_second >= 0);

                result = (short)(sl_first + sl_second);

                bool difficult = rand.Next(100) < 50 ? true : false;

                if (difficult == false)
                {
                    if (sl_second < 0)
                    {
                        return $"{sl_first} + ({sl_second}) =";
                    }
                    else return $"{sl_first} + {sl_second} =";
                }
                else
                {
                    if (sl_second < 0)
                    {
                        return $"{sl_first} - {sl_second * -1} =";
                    }
                    else return $"{sl_first} + {sl_second} =";
                }
            }
            else
            {
                short sl_first, sl_second, sl_third;
                do
                {
                    sl_first = (short)rand.Next(-30, 30);
                    sl_second = (short)rand.Next(-30, 30);
                    sl_third = (short)rand.Next(-30, 30);
                }
                while (sl_first >= 0 && sl_second >= 0 && sl_third >= 0);

                result = (short)(sl_first + sl_second + sl_third);

                if (sl_second < 0 && sl_third < 0)
                    return $"{sl_first} + ({sl_second}) + ({sl_third}) =";
                else if (sl_second > 0 && sl_third < 0)
                    return $"{sl_first} + {sl_second} + ({sl_third}) =";
                else if (sl_second < 0 && sl_third > 0)
                    return $"{sl_first} + ({sl_second}) + {sl_third} =";
                else if (sl_second > 0 && sl_third > 0)
                    return $"{sl_first} + {sl_second} + {sl_third} =";
                else return "Попробуйте снова!";
            }
        }

        private void Click_BackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void Click_CheckButton(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Convert.ToInt32(TextBoxExResult.Text) == result)
                {
                    Message.Content = "Верно!";
                    Message.Foreground = Brushes.LightGreen;
                    Message.Visibility = Visibility.Visible;
                }
                else
                {
                    Message.Content = "Неверно!";
                    Message.Foreground = Brushes.Red;
                    Message.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                Message.Content = "Возникла ошибка при вводе данных!";
                Message.Foreground = Brushes.Red;
                Message.Visibility = Visibility.Visible;
            }

            if (TextBoxExResult.Text == "")
            {
                Message.Content = "Данные не введены";
                Message.Foreground = Brushes.Red;
                Message.Visibility = Visibility.Visible;
            }

        }

        private void Click_NewExerciseButton(object sender, RoutedEventArgs e)
        {
            TextBoxExResult.Text = ""; Message.Visibility = Visibility.Collapsed;
            TextBoxExercise.Text = CreatingExercise();
        }
    }
}
