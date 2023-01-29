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
        private byte taskNumber = 0, completedTaskNumber = 0;
        private short result;

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

        public string CreateExercise()
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

        private void ClickBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ClickCheckButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (taskNumber < 10)
                {
                    if (Convert.ToInt32(TextBoxResult.Text) == result)
                    {
                        messageLabel.Content = "Верно!";
                        messageLabel.Foreground = Brushes.Green;
                        messageLabel.Visibility = Visibility.Visible;
                        completedTaskNumber++;
                        updateIsEnabledOfTextBoxResultAndButtonCheck(false);
                    }
                    else
                    {
                        messageLabel.Content = "Неверно!";
                        messageLabel.Foreground = Brushes.Red;
                        messageLabel.Visibility = Visibility.Visible;
                        updateIsEnabledOfTextBoxResultAndButtonCheck(false);
                    }
                }
                else
                {
                        MessageBox.Show("Вы уже прошли тест!");
                }
            }
            catch
            {
                messageLabel.Content = "Возникла ошибка при вводе данных!";
                messageLabel.Foreground = Brushes.Red;
                messageLabel.Visibility = Visibility.Visible;
            }

            if (TextBoxResult.Text == "")
                {
                    messageLabel.Content = "Данные не введены";
                    messageLabel.Foreground = Brushes.Red;
                    messageLabel.Visibility = Visibility.Visible;
                }
            
        }

        private void ClickNewExerciseButton(object sender, RoutedEventArgs e)
        {
            updateIsEnabledOfTextBoxResultAndButtonCheck(true);
            if (taskNumber < 10)
            {
                TextBoxResult.Text = ""; messageLabel.Visibility = Visibility.Collapsed;
                updateTaskNumberTextBlock();
                TextBoxExercise.Text = CreateExercise();
            }
            else
            {
                MessageBox.Show($"Вы завершили тест, выполнив заданий: {completedTaskNumber}");
            }
        }

        private void updateTaskNumberTextBlock()
        {
            if (taskNumber < 10)
            {
                taskNumber++;
                taskNumberTextBlock.Text = $"Задание {taskNumber}/10";
            }
        }
        private void updateIsEnabledOfTextBoxResultAndButtonCheck(bool isEnabled)
        {
            if(isEnabled)
            {
                ButtonCheck.IsEnabled = true;
                TextBoxResult.IsEnabled = true;
            }
            else
            {
                ButtonCheck.IsEnabled = false;
                TextBoxResult.IsEnabled = false;
            }
        }
    }
}
