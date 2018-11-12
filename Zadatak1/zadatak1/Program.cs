using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ExportClass : Attribute
{

}

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ExportProperty : Attribute
{

}

namespace CustomExpresions
{
    using zadatak1;
    public static class Expresions
    {
        public static void Printf(this MyExpression exp)
        {
            Console.WriteLine(exp.GetString());
        }
    }
}


namespace zadatak1
{
    using CustomExpresions;
    using System.IO;

    class Program
    {

        static void Main(string[] args)
        {

            var constExpression1 = new ConstExpression(3);
            var constExpression2 = new ConstExpression(4);
            var parametarExpressionX = new ParametarExpression("x");
            var parametarExpressionY = new ParametarExpression("y");
            var parametarExpressionA = new ParametarExpression("a");
            var parametarExpressionB = new ParametarExpression("b");
            var binaryExpressionAdd = new BinaryExpression(parametarExpressionX, parametarExpressionY, "+", true);
            var binaryExpressionMul = new BinaryExpression(constExpression2, binaryExpressionAdd, "*", false);

            var binaryExpressionMul2 = new BinaryExpression(parametarExpressionA, parametarExpressionB, "*", false);
            var binaryExpressionAdd2 = new BinaryExpression(binaryExpressionMul2, binaryExpressionMul, "+", true);

            var binaryExpressionMul3 = new BinaryExpression(constExpression1, binaryExpressionAdd2, "*", false);

            Console.Write("Za izraz: ");
            binaryExpressionMul3.Printf();

            Parametar[] array = new Parametar[4];
            List<Parametar> lst = new List<Parametar>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Unesite parametar i njegovu vrednost:");
                lst.Add(new Parametar(Console.ReadLine(), double.Parse(Console.ReadLine())));
            }

            Console.Write("Resenje je: ");
            Console.WriteLine(binaryExpressionMul3.Compile()(lst));
        }
    }
}
