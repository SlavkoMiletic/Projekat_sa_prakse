using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace zadatak1
{
    [Serializable]
    //[XmlInclude(typeof(ConstExpression))]
    //[XmlInclude(typeof(ParametrExpression))]
    //[XmlInclude(typeof(BinaryExpression))]
    public abstract class MyExpression : IXmlSerializable
    {
        public abstract Func<List<Parametar>, double> Compile();
        public abstract XmlSchema GetSchema();
        public abstract string GetString();
        public abstract void ReadXml(XmlReader reader);
        public abstract void WriteXml(XmlWriter writer);

        static public MyExpression operator +(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "+", false);

        static public MyExpression operator -(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "-", false);

        static public MyExpression operator *(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "*", false);

        static public MyExpression operator /(MyExpression exp1, MyExpression exp2) => new BinaryExpression(exp1, exp2, "/", false);

    }
}
