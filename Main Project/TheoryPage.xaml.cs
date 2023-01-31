﻿using System;
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
    /// Логика взаимодействия для TheoryPage.xaml
    /// </summary>
    public partial class TheoryPage : Page
    {
        string login;

        public TheoryPage(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        short page_count = 1;
        //Отвечает за счетчик перемещения по страницам.

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxPage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Click_NextButton(object sender, RoutedEventArgs e)
        {
            switch (page_count + 1)
            {
                case 2:
                    TextBoxTheory.Text = "Если же игрок за одну игру получил 3 штрафных очка, а за вторую 5 штрафных очков, то общее число штрафных очков находим также сложением. Если выразить числа штрафных очков отрицательными числами, то получим (-3) + (-5) = - 8. Число —8, а также выражение (-3) + (-5) — это сумма чисел —3 и —5. Числа —3 и —5 — слагаемые. Первое слагаемое обычно записывают без скобки: -3 + (-5).";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 3:
                    TextBoxTheory.Text = "Пользуясь этим примером, можно сложить два любых отрицательных числа, например: \n-6 + (-5) = -11  \n-1 + (-15) = -16 \n-47 + (-3,2) = -50,2";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 4:
                    TextBoxTheory.Text = "Мы видим, что сумма двух отрицательных чисел есть число отрицательное, модуль которого равен сумме модулей слагаемых. Значит, чтобы сложить два отрицательных числа, нужно: \n1) сложить модули слагаемых; \n2) перед полученным числом поставить знак «—».";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 5:
                    TextBoxTheory.Text = "Допустим, что игрок получил за одну партию игры 5 штрафных очков, а за вторую партию 5 выигрышных очков. В этом случае ни то ни другое число не имеет перевеса и в итоге результат игры равен нулю. Запишем: -5 + 5 = 0.Таким же образом получим, например: \n-10 - 10 = 0, \n7 + (-7) = 0 \nи т.д. Вообще сумма двух противоположных чисел равна нулю.";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 6:
                    TextBoxTheory.Text = "Рассмотрим теперь сложение двух чисел с разными знаками, модули которых не равны. Допустим, что игрок получил за одну партию 5 штрафных, а за вторую 7 выигрышных очков. Так как число выигрышных очков имеет над числом штрафных очков перевес в 2 очка, то в результате двух партий игрок имеет 2 выигрышных очка. Запишем: \n-5 + 7 = 2.";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 7:
                    TextBoxTheory.Text = "Если же игрок получил за одну партию 5 выигрышных, а за вторую 7 штрафных очков, то в итоге он имеет 2 штрафных очка. Запишем: 5 + (-7) = -2. Пользуясь этим примером, можно сложить любые два числа с разными знаками, модули которых не равны, например:";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 8:
                    TextBoxTheory.Text = "-50 + 40 = -10, \n25 + (-5) = 20, \n-0,2 + 0,3 = 0.1, \n8 + (-9) = -1.";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 9:
                    TextBoxTheory.Text = "Мы видим, что сумма таких чисел может быть как положительной, так и отрицательной. От чего зависит знак суммы? Очевидно, знак суммы совпадает со знаком того слагаемого, модуль которого больше.Но чтобы найти модуль суммы, нужно из большего модуля вычесть меньший. Итак, чтобы сложить два числа с разными знаками, модули которых не равны, нужно:";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 10:
                    TextBoxTheory.Text = "1) из большего модуля вычесть меньший модуль; \n2) перед полученным числом поставить знак того слагаемого, модуль которого больше.";
                    page_count++;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 11:
                    TextBoxTheory.Text = "Если одно из слагаемых равно нулю, то сумма равна другому слагаемому. Например: \n0 + (-5) = -5 \n-7,8 + 0 = -7,8.";
                    page_count++;
                    TextBoxPage.Text = "11/11";
                    break;
            }
        }

        private void Click_PreviousButton(object sender, RoutedEventArgs e)
        {
            switch (page_count - 1)
            {
                case 1:
                    TextBoxTheory.Text = "Ты, наверное, знаешь такие игры (например, домино), в которых выигравший может получить определенное число (выигранных) очков, а проигравший — штрафных очков. Если, например, игрок за одну игру выиграл 3 очка, а за вторую 5 очков, то общее число выигранных очков находим сложением: 3 + 5 = 8, или можно записать: ( + 3) + ( + 5)= +8. ";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 2:
                    TextBoxTheory.Text = "Если же игрок за одну игру получил 3 штрафных очка, а за вторую 5 штрафных очков, то общее число штрафных очков находим также сложением. Если выразить числа штрафных очков отрицательными числами, то получим (-3) + (-5) = - 8. Число —8, а также выражение (-3) + (-5) — это сумма чисел —3 и —5. Числа —3 и —5 — слагаемые. Первое слагаемое обычно записывают без скобки: -3 + (-5).";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 3:
                    TextBoxTheory.Text = "Пользуясь этим примером, можно сложить два любых отрицательных числа, например: \n-6 + (-5) = -11  \n-1 + (-15) = -16 \n-47 + (-3, 2) = -50,2";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 4:
                    TextBoxTheory.Text = "Мы видим, что сумма двух отрицательных чисел есть число отрицательное, модуль которого равен сумме модулей слагаемых. Значит, чтобы сложить два отрицательных числа, нужно: \n1) сложить модули слагаемых; \n2) перед полученным числом поставить знак «—».";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 5:
                    TextBoxTheory.Text = "Допустим, что игрок получил за одну партию игры 5 штрафных очков, а за вторую партию 5 выигрышных очков. В этом случае ни то ни другое число не имеет перевеса и в итоге результат игры равен нулю. Запишем: -5 + 5 = 0.Таким же образом получим, например: \n-10 - 10 = 0, \n7 + (-7) = 0 \nи т.д. Вообще сумма двух противоположных чисел равна нулю.";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 6:
                    TextBoxTheory.Text = "Рассмотрим теперь сложение двух чисел с разными знаками, модули которых не равны. Допустим, что игрок получил за одну партию 5 штрафных, а за вторую 7 выигрышных очков. Так как число выигрышных очков имеет над числом штрафных очков перевес в 2 очка, то в результате двух партий игрок имеет 2 выигрышных очка. Запишем: -5 + 7 = 2.";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 7:
                    TextBoxTheory.Text = "Если же игрок получил за одну партию 5 выигрышных, а за вторую 7 штрафных очков, то в итоге он имеет 2 штрафных очка. Запишем: 5 + (-7) = -2. Пользуясь этим примером, можно сложить любые два числа с разными знаками, модули которых не равны, например:";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 8:
                    TextBoxTheory.Text = "-50 + 40 = -10, \n25 + (-5) = 20, \n-0,2 + 0,3 = 0.1, \n8 + (-9) = -1.";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 9:
                    TextBoxTheory.Text = "Мы видим, что сумма таких чисел может быть как положительной, так и отрицательной. От чего зависит знак суммы? Очевидно, знак суммы совпадает со знаком того слагаемого, модуль которого больше.Но чтобы найти модуль суммы, нужно из большего модуля вычесть меньший. Итак, чтобы сложить два числа с разными знаками, модули которых не равны, нужно:";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
                case 10:
                    TextBoxTheory.Text = "1) из большего модуля вычесть меньший модуль; \n2) перед полученным числом поставить знак того слагаемого, модуль которого больше.";
                    page_count--;
                    TextBoxPage.Text = (page_count + "/11");
                    break;
            }
        }

        private void ClickBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage(login));
        }
    }
}
