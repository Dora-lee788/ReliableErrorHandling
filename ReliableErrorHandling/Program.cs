using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliableErrorHandling
{ 
        class Program
        {
            static void Main()
            {
                string[] orders =
                {
                "ORDER001;150.50;3",
                "плохая строка",
                "ORDER002;-10;1",
                "ORDER003;200;2"
            };

                OrderProcessor processor = new OrderProcessor();
                processor.Process(orders);
            }
        }
    }




