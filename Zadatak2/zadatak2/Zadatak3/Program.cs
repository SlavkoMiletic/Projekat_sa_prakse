using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using zadatak1;

namespace Zadatak3
{
    class Program
    {
        static void Main(string[] args)
        {
            var parametarExpressionX = new ParametarExpression("x");
            var parametarExpressionY = new ParametarExpression("y");
            var parametarExpressionZ = new ParametarExpression("z");

            List<Parametar> lista = new List<Parametar>()
            {
                new Parametar("x", 2),
                new Parametar("y", 4),
                new Parametar("z", 6)
            };

            List<IExpressionManipulator> list = new List<IExpressionManipulator>();
            
            Assembly assembly = Assembly.GetExecutingAssembly();

            List<Type> types = assembly.GetTypes().Where(t => 
                t.GetInterfaces().Contains(typeof(IExpressionManipulator))).ToList();

            List<MyExpression> lst = new List<MyExpression>() { parametarExpressionX, parametarExpressionY, parametarExpressionZ };

            foreach (Type t in types)
            {
                if (t == typeof(AverageManipulator))
                {
                    ConstructorInfo ctop = typeof(AverageManipulator).GetConstructor(new[] { typeof(List<MyExpression>) });
                    object instance = ctop.Invoke(new object[] { lst });
                    list.Add((IExpressionManipulator)instance);
                }
                else
                {
                    IExpressionManipulator instance = (IExpressionManipulator)Activator.CreateInstance(t);
                    instance.Lst.AddRange(lst);
                    list.Add(instance);
                }
            }

            foreach (var obj in list)
            {
                Console.WriteLine(obj.Manipulate().Compile()(lista));
            }
        }
    }
}
