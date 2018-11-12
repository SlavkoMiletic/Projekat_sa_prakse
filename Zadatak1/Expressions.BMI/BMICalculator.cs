using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ExportClass : Attribute
{
    public double ExportProperty { get; set; }
}
namespace Expressions.BMI
{
    [ExportClass]
    public class BMICalculator : ExportClass
    {
        public double Mass { get; set; }
        public double Height { get; set; }
        public double BMI { get => ExportProperty; }

    }
}
