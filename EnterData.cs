using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model_Work
{
    class EnterData
    {

        public int EnterNumber(string message)
        {
            while (true)
            {
                Console.Write(message);
                int value;
                string str = Console.ReadLine();

                try
                {
                    value = Convert.ToInt32(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nФормат введених даних не є int. Спробуйте знов");
                    continue;
                }

                return value;
            }
        }

        public string EnterString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
