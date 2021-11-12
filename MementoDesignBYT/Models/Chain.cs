using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignBYT.Models
{
    interface Chain
    {
        public abstract Calculation calculate(Calculation calculation);
        public abstract void setNext(Chain nextInChain);
    }
}
