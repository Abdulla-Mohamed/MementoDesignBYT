using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MementoDesignBYT.Models
{
    class AdditionCalculation : Chain
    {
        private Chain NextInChain;

        public Calculation calculate(Calculation calculation)
        {
            if(!calculation.OperationSign.Equals("+")  )
            {
                NextInChain.calculate(calculation);
                return calculation;
            }
            else
            {
                float _result = calculation.Arg1 + calculation.Arg2;
                calculation.result = _result;
                return calculation;
            }
        }

        public void setNext(Chain nextInChain)
        {
            this.NextInChain = nextInChain;
        }

    }
}
