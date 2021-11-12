using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignBYT.Models
{
    class Calculation
    {
        public float Arg1 { get; set; }
        public float Arg2 { get; set; }
        public string OperationSign { get; set; }
        public float result { get; set; }

        public Calculation (float arg1, float arg2, string operationSign)
        {
            Arg1 = arg1;
            Arg2 = arg2;
            OperationSign = operationSign;
        }

        public Calculation()
        {
            Arg1 = 0f;
            Arg2 = 0f;
            OperationSign = "+";
        }

       
    }
}
