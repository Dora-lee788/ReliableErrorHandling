using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliableErrorHandling
{
        public class OrderProcessingException : Exception
        {
            public OrderProcessingException() { }
            public OrderProcessingException(string message) : base(message) { }
            public OrderProcessingException(string message, Exception innerException) : base(message, innerException) { }
        }
}




