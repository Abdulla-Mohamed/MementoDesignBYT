using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignBYT.Models
{
    class InvalidSign : Chain
    {
        private Chain NextInChain;
        public Calculation calculate(Calculation calculation)
        {
            if (!calculation.OperationSign.Equals("+") && !calculation.OperationSign.Equals("-") && !calculation.OperationSign.Equals("*") && !calculation.OperationSign.Equals("/"))
            {
                Console.Write("InvalidOprationSign = ");
                calculation.result = 0;
                return calculation;
            }
            else
            {
                NextInChain.calculate(calculation);
                return calculation;
            }
        }

        public void setNext(Chain nextInChain)
        {
            this.NextInChain = nextInChain;
        }

    }
}
