using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using zadatak1;


namespace zadatak2
{

    class Program
    {
        static void Main(string[] args)
        {

            List<object> assemblyObjects = new List<object>();

            string dir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            string[] paths = Directory.GetFiles(dir, "Expressions.*.dll");

            foreach (string path in paths)
            {
                var assembly = Assembly.LoadFrom(path);
                
                List<Type> assemblyTypes = assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(ExportClass))).ToList();
                assemblyTypes.ForEach(t =>
                {
                    var instance = Activator.CreateInstance(t);
                    assemblyObjects.Add(instance);
                });
            }

            assemblyObjects.ForEach(o =>
            {
                o.GetType().GetProperty("Mass").SetValue(o, (ParametarExpression)"Mass");
                o.GetType().GetProperty("Height").SetValue(o, (ParametarExpression)"Height");

            });

            List<Parametar> lista = new List<Parametar>
            {
                new Parametar("Mass", 100),
                new Parametar("Height", 1.9)
            };
            
            assemblyObjects.ForEach(o =>
            {
                List<PropertyInfo> properties = o.GetType().GetProperties().Where(t => 
                    Attribute.IsDefined(t, typeof(ExportProperty))).ToList();

                properties.ForEach(property =>
                {
                    MyExpression exp = (MyExpression)property.GetValue(o);
                    Console.WriteLine(exp.Compile()(lista));
                });
            });
        }
    }
}
