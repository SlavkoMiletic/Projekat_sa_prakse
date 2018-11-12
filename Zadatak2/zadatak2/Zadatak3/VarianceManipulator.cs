using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadatak1;

namespace Zadatak3
{
    class VarianceManipulator : IExpressionManipulator
    {

        private List<MyExpression> lst;

        public List<MyExpression> Lst
        {
            get
            {
                if (this.lst == null)
                {
                    this.lst = new List<MyExpression>();
                }
                return this.lst;
            }
        }

        public MyExpression Manipulate()
        {
            var instanca = new AverageManipulator(this.lst);

            MyExpression s = (ConstExpression)0;

            if (this.lst != null)
            {
                int br = 0;

                foreach (MyExpression exp in Lst)
                {
                    s = s + ((exp - instanca.Manipulate()) * (exp - instanca.Manipulate()));
                    br++;
                }
                return s / (ConstExpression)(br - 1);
            }
            else
                return s;
            
        }       
    }
}
