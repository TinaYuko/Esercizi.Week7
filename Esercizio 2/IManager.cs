using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    interface IManager<T>
    {
        public List<T> GetAll();

    }
}
