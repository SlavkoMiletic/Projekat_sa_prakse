using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadatak1;

namespace Zadatak3
{
    interface IExpressionManipulator
    {
        List<MyExpression> Lst { get; }
        MyExpression Manipulate();
    }
}
