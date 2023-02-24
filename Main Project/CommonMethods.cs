using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project
{
    //статический класс для методов, которые могут использовоаться во всей программе, для примера - метода вывода сообщения в консоль отладки,
    //он исполняется в событии пр иподключении бд
    internal static class CommonMethods
    {
        public static void GetConnectionStatus(string message) => Debug.WriteLine(message);

    }
}
