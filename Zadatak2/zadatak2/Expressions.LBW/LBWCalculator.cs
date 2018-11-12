using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using zadatak1;


namespace Expressions.LBW
{
    [ExportClass]
    public class LBWCalculator
    {
        public ParametarExpression Mass { get; set; }
        public ParametarExpression Height { get; set; }
        [ExportProperty]
        public MyExpression LBW { get => ((ConstExpression)1.09 * Mass) - (ConstExpression) 128 * ((Mass * Mass) / (((ConstExpression)100 * Height) * ((ConstExpression)100 * Height))); }

    }
}
