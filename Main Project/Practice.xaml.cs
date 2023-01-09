using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Main_Project
{
    public partial class Practice : Window
    {
        public Practice()
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
                    sl_first    = (short)rand.Next(-30, 30);
                    sl_second   = (short)rand.Next(-30, 30);
                    sl_third    = (short)rand.Next(-30, 30);
                }
                while (sl_first >= 0 && sl_second >= 0 && sl_third >=0);                

                result = (short)(sl_first + sl_second + sl_third);

                if (sl_second < 0 && sl_third < 0)
                    return $"{sl_first} + ({sl_second}) + ({sl_third}) =";
                else if (sl_second > 0 && sl_third < 0)
                    return $"{sl_first} + {sl_second} + ({sl_third}) =";
                else if (sl_second < 0 && sl_third > 0)
                    return $"{sl_first} + ({sl_second}) + {sl_third} =";
                else if (sl_second > 0 && sl_third > 0)
                    return $"{sl_first} + {sl_second} + {sl_third} =";
            }
        }

        private void Click_BackButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Hide();
            mainwindow.Show();
        }

        private void Click_CheckButton(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Convert.ToInt32(TextBoxExResult.Text) == result)
                {
                    Message.Content     = "Верно!";
                    Message.Foreground  = Brushes.LightGreen;
                    Message.Visibility  = Visibility.Visible;
                }
                else
                {
                    Message.Content     = "Неверно!";
                    Message.Foreground  = Brushes.Red;
                    Message.Visibility  = Visibility.Visible;
                }
            }
            catch
            {
                Message.Content     = "Возникла ошибка при вводе данных!";
                Message.Foreground  = Brushes.Red;
                Message.Visibility  = Visibility.Visible;
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