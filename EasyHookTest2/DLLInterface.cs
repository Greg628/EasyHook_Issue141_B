using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyHookTest2
{
    public class DLLInterface : MarshalByRefObject
    {
        public void Message(string s)
        {
            Console.WriteLine(s);
        }
    }
}
