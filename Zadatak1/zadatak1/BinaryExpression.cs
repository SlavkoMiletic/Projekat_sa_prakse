using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace zadatak1
{
    [Serializable]
    public class BinaryExpression : MyExpression
    {
        private MyExpression left;
        private MyExpression right;
        private string operation;
        private readonly bool flag;

        public MyExpression Left { get => this.left; set => this.left = value; }
        public MyExpression Right { get => this.right; set => this.right = value; }
        public string Operation { get => this.operation; set => this.operation = value; }


        public BinaryExpression(MyExpression left, MyExpression right, string op, bool flag)
        {
            this.left = left;
            this.right = right;
            this.operation = op;
            this.flag = flag;
        }

        public BinaryExpression() { }


        public override Func<List<Parametar>, double> Compile()
        {
            return x => (this.operation == "+") ? left.Compile()(x) + right.Compile()(x)
                        : (this.operation == "-") ? left.Compile()(x) - right.Compile()(x)
                        : (this.operation == "*") ? left.Compile()(x) * right.Compile()(x)
                        : left.Compile()(x) / right.Compile()(x);
        }

        public override string GetString() => (this.flag) ?
            string.Format("(" + this.left.GetString() + this.operation + this.right.GetString() + ")") :
            string.Format(this.left.GetString() + this.operation + this.right.GetString());

        public override XmlSchema GetSchema()
        {
            return null;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();
            this.left = ExpressionFactory.Create(reader.Name);
            this.left.ReadXml(reader);
            this.operation = reader.ReadElementContentAsString();
            this.right = ExpressionFactory.Create(reader.Name);
            this.right.ReadXml(reader);
            reader.ReadEndElement();
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(this.left.GetType().Name);
            this.left.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("Operacija", this.operation);
            writer.WriteStartElement(this.right.GetType().Name);
            this.right.WriteXml(writer);
            writer.WriteEndElement();
        }
    }

    internal static class ExpressionFactory
    {
        internal static MyExpression Create(string typeDescription)
        {
            switch (typeDescription)
            {
                case "BinaryExpression": return new BinaryExpression();
                case "ConstExpression": return new ConstExpression();
                case "ParametarExpression": return new ParametarExpression();
                default: throw new ArgumentException();
            }
        }
    }
}
