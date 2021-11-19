using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    class NumeroComplessoException : Exception
    {

        public NumeroComplesso PrimoOperatore { get; set; }
        public NumeroComplesso SecondoOperatore { get; set; }

        public NumeroComplessoException()
        {

        }
        public NumeroComplessoException(string messaggio) : base (messaggio)
        {
            
        }
        public NumeroComplessoException(string messaggio, Exception innerException) : base (messaggio, innerException)
        {

        }
        protected NumeroComplessoException(SerializationInfo info, StreamingContext context) : base(info, context )
        {

        }

        
    }
}
