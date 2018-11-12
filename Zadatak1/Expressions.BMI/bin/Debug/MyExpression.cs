using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace zadatak1
{
    public abstract class MyExpression
    {
        public abstract Func<List<Parametar>, double> Compile();

        public abstract string GetString(MyExpression exp);

        static public MyExpression operator +(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "+", false);

        static public MyExpression operator -(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "-", false);

        static public MyExpression operator *(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "*", false);

        static public MyExpression operator /(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "/", false);

    }
}
