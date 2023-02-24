using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class PracticePage : Page
    {
        readonly dblearningmath dblearningmath = new dblearningmath();

        private byte taskNumber = 0, completedTaskNumber = 0;
        private short result;
        bool isTestActive= false;

        public PracticePage()
        {
            InitializeComponent();
            newExerciseButton.Content = "Начать тест";
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
                    if (Convert.ToInt32(resultTextBox.Text) == result)
                    {
                        UpdateMessageBox("Верно!", true);
                        completedTaskNumber++;
                        UpdateIsEnabledOfTextBoxResultAndButtonCheck(false);
                    }
                    else
                    {
                        UpdateMessageBox("Неверно!", false);
                        UpdateIsEnabledOfTextBoxResultAndButtonCheck(false);
                    }
                }
                else
                {
                    EndTest();
                }
            }
            catch
            {
                UpdateMessageBox("Возникла ошибка при вводе данных!", false);
            }

            if (resultTextBox.Text == "")
                {
                    UpdateMessageBox("Данные не введены", false);
                }
            
        }

        private void ClickNewExerciseButton(object sender, RoutedEventArgs e)
        {
            if(!isTestActive)
            {
                isTestActive= true;
                newExerciseButton.Content = "Новый пример";
            }
            UpdateIsEnabledOfTextBoxResultAndButtonCheck(true);
            if (taskNumber < 10)
            {
                resultTextBox.Text = ""; messageLabel.Visibility = Visibility.Collapsed;
                UpdateTaskNumberTextBlock();
                exerciseTextBox.Text = CreateExercise();
            }
            else
            {
                EndTest();
            }
        }

        private void UpdateTaskNumberTextBlock()
        {
            if (taskNumber < 10)
            {
                taskNumber++;
                taskNumberTextBlock.Text = $"Задание {taskNumber}/10";
            }
        }

        private void UpdateIsEnabledOfTextBoxResultAndButtonCheck(bool isEnabled)
        {
            if(isEnabled)
            {
                ButtonCheck.IsEnabled = true;
                resultTextBox.IsEnabled = true;
            }
            else
            {
                ButtonCheck.IsEnabled = false;
                resultTextBox.IsEnabled = false;
            }
        }

        private void EndTest()
        {
            isTestActive = false;
            MessageBox.Show($"Вы завершили тест, выполнив заданий: {completedTaskNumber}");
            taskNumber = 0;
            taskNumberTextBlock.Text = $"Задание 0/10";
            newExerciseButton.Content = "Начать тест";
            exerciseTextBox.Text = "";

            string createResultQuery = $"INSERT results VALUES ((SELECT user_id from users WHERE login='{Account.Login}'), 'Сложение и вычитание отрицательных чисел', {completedTaskNumber})";
            
            dblearningmath.OpenConnection();
            SqlCommand commandResultInsert = new SqlCommand(createResultQuery, dblearningmath.GetConnection());
            commandResultInsert.ExecuteScalar();
            dblearningmath.CloseConnection();

            completedTaskNumber = 0;
        }

        private void UpdateMessageBox(string message, bool messageType)
        {
            if(messageType)
            {
                messageLabel.Content = message;
                messageLabel.Foreground = Brushes.Green;
                messageLabel.Visibility = Visibility.Visible;
            }
            else
            {
                messageLabel.Content = message;
                messageLabel.Foreground = Brushes.Red;
                messageLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
