using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    class BinaryExpression : MyExpression
    {
        private MyExpression left;
        private MyExpression right;
        private string operacija;
        private bool flag;



        public BinaryExpression(MyExpression left, MyExpression right, string op, bool flag)
        {
            this.left = left;
            this.right = right;
            operacija = op;
            this.flag = flag;
        }


        public override Func<List<Parametar>, double> Compile()
        {
            return x =>   (this.operacija == "+") ? left.Compile()(x) + right.Compile()(x) 
                        : (this.operacija == "-") ? left.Compile()(x) - right.Compile()(x) 
                        : (this.operacija == "*") ? left.Compile()(x) * right.Compile()(x) 
                        : left.Compile()(x) / right.Compile()(x);
        }

        public override string GetString(MyExpression exp) => (this.flag) ? string.Format("(" + this.left.GetString(exp) + this.operacija + this.right.GetString(exp) + ")")
                                                                          : string.Format(this.left.GetString(exp) + this.operacija + this.right.GetString(exp));
        
    }
}
