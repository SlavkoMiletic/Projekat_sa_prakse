using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace CustomExpresions
{
    using zadatak1;
    public static class Expresions
    {
        public static void Printf(this MyExpression exp)
        {
            Console.WriteLine(exp.GetString(exp));
        }
    }
}

//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
//public class ExportClass : Attribute
//{
//    public string ExportProperty { get; set; }
//}



namespace zadatak1
{
    using CustomExpresions;

    class Program
    {
        
        static void Main(string[] args)
        {

            var a = new ConstExpression(3);
            var b = new ConstExpression(4);
            var c = new ParametrExpression("x");
            var d = new ParametrExpression("y");
            var e = new ParametrExpression("a");
            var f = new ParametrExpression("b");
            var g = new BinaryExpression(c, d, "+", true);
            var h = new BinaryExpression(b, g, "*", false);
            var j = new BinaryExpression(e, f, "*", false);
            var p = new BinaryExpression(j, h, "+", true);
            var q = new BinaryExpression(a, p, "*", false);

            Console.Write("Za izraz: ");
            q.Printf();
            
            //Parametar[] array = new Parametar[4];
            List<Parametar> lst = new List<Parametar>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Unesite parametar i njegovu vrednost:");
                lst.Add(new Parametar(Console.ReadLine(), double.Parse(Console.ReadLine())));
            }
            
            Console.Write("Resenje je: ");
            Console.WriteLine(q.Compile()(lst));

            //var help = new ExportClass();
            //var method12 = new BMICalculator();
            //help.ExportProperty = method12.BMI;
            //Console.WriteLine(help.ExportProperty);
            //var tmp = new ExportClass();
            //Type type = typeof(BMICalculator);
            //PropertyInfo[] properties = type.GetProperties();
            //foreach (PropertyInfo property in properties)
            //{
            //    Console.WriteLine(property.PropertyType);
            //}

            //List<Assembly> Assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Expression")).ToList();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Assembly> myAssemblies = new List<Assembly>();
            foreach (Assembly item in assemblies)
            {
                if (item.GetName().Name.Contains("Expression"))
                {
                    myAssemblies.Add(item);
                }
            }



        }
    }
}
