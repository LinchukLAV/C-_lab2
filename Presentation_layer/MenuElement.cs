using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer
{
    public class MenuElement
    {
        private string _title;
        private Action _action;

        public MenuElement(string title, Action action)
        {
            _title = title;
            _action = action;
        }

        public void ExecuteElement()
        {
            _action.Invoke();
        }

        public void Display()
        {
            Console.WriteLine(_title);
        }
    }
}
