using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadatak1;

namespace Zadatak3
{
    class AverageManipulator : IExpressionManipulator
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

        public AverageManipulator(List<MyExpression> lst)
        {
            this.lst = lst;
        }

        public MyExpression Manipulate()
        {
            MyExpression s = (ConstExpression)0;

            if (lst.Capacity != 0)
            {
                int br = 0;
                foreach (MyExpression exp in lst)
                {
                    s = s + exp;
                    br++;
                }
                return s / (ConstExpression)br;
            }
            else
                return s;
        }
    }
}
