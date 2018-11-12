using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using zadatak1;

namespace Expression.BMI
{
    [ExportClass]
    public class BMICalculator
    {
        public ParametarExpression Mass { get; set; }
        public ParametarExpression Height { get; set; }
        [ExportProperty]
        public MyExpression BMI { get => Mass / (Height * Height) ; }
    }
}
