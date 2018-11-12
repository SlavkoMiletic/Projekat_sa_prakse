using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using zadatak1;

namespace Zadatak4
{
    using CustomExpresions;
    using System.IO;
    using System.Threading;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    using System.Xml;

    class Program
    {
 
        public static void Serialize(ExpressionContainer exp)
        {
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExpressionContainer));
                using (StreamWriter sw = new StreamWriter("Expression.xml"))
                { 
                    xmlSerializer.Serialize(sw, exp, ns);
                    sw.Close();
                }
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Success");
        }

        public static void Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExpressionContainer));
                StreamReader sr = new StreamReader("Expression.xml");
                ExpressionContainer exp = (ExpressionContainer)xmlSerializer.Deserialize(sr);
                sr.Dispose();

                Console.WriteLine("Informations:");
                Console.WriteLine("Name: " + exp.Name);
                Console.WriteLine("id: " + exp.Id);
                Console.WriteLine("Date Created: " + exp.DateCreated);
                Console.WriteLine("Date Modify: " + exp.DateModify);
                Console.WriteLine("Expression: " + exp.Expression.GetString());
                Console.WriteLine("============================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            var expressionContainerA = new ExpressionContainer("a", (ConstExpression)3);
            var expressionContainerB = new ExpressionContainer("b", (ConstExpression)4);
            var expressionContainerC = new ExpressionContainer("c", (ParametarExpression)"x");

            var constExpression1 = new ConstExpression(3);
            var parametarExpressionX = new ParametarExpression("x");
            var binaryExpressionMul = new BinaryExpression(constExpression1, parametarExpressionX, "*", false);

            var constExpression2 = new ConstExpression(15);
            var parametarExpressionY = new ParametarExpression("y");
            var binaryExpressionDiv = new BinaryExpression(constExpression2, parametarExpressionY, "/", false);

            var constExpression3 = new ConstExpression(4);
            var binaryExpressionSub = new BinaryExpression(binaryExpressionDiv, constExpression3, "-", false);

            var binaryExpressionAdd = new BinaryExpression(binaryExpressionMul, binaryExpressionSub, "+", false);

            var expressionContainerIme = new ExpressionContainer("ime", binaryExpressionAdd);
            
            var binaryExpressionMul2 = new BinaryExpression(binaryExpressionMul, parametarExpressionY, "*", false);
            var expressionContainerIme2 = new ExpressionContainer("ime", binaryExpressionMul2);

            List<ExpressionContainer> lista = new List<ExpressionContainer>() { expressionContainerA, expressionContainerB, expressionContainerC };

            Thread t1 = new Thread(() => ExpressionSingleton.Instance.ListId(lista).ForEach(t => Console.WriteLine("t1 " + t.ToString())));

            Thread t2 = new Thread(() =>
            {
                ExpressionSingleton.Instance.ChangeName(expressionContainerA, "Novi");
                Console.WriteLine("t2 " + expressionContainerA.Name);
            });
            
            Thread t3 = new Thread(() =>
            {
                ExpressionSingleton.Instance.ChangeExpression(expressionContainerA, parametarExpressionY);
                expressionContainerA.Expression.Printf();
            });

            Thread t4 = new Thread(() => ExpressionSingleton.Instance.ListId(lista).ForEach(t => Console.WriteLine("t4 " + t.ToString())));

            t1.Start();
            t4.Start();
            t2.Start();
            t3.Start();


            Serialize(expressionContainerIme);
            Deserialize();

            //Console.ReadLine();
        }
    }
}
