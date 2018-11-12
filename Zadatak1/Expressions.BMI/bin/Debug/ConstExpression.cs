using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    class ConstExpression : MyExpression
    {
        private double value;

        public ConstExpression(double value)
        {
            this.value = value;
        }


        public override Func<List<Parametar>, double> Compile()
        {
            return x => this.value;
        }

        public override string GetString(MyExpression exp) => string.Format(this.value.ToString());

        static public implicit operator ConstExpression(double num)
        {
            return new ConstExpression(num);
        }
    }
}
