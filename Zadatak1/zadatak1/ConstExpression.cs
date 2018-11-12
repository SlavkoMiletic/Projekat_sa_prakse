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
    public class ConstExpression : MyExpression
    {
        private double value;

        public double Value { get => this.value; set => this.value = value; }

        public ConstExpression(double value)
        {
            this.value = value;
        }
      
        public ConstExpression() { }


        public override Func<List<Parametar>, double> Compile()
        {
            return x => this.value;
        }

        public override string GetString() => string.Format(this.value.ToString());

        public override XmlSchema GetSchema()
        {
            return null;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            this.value = double.Parse(reader.ReadElementContentAsString());
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.value.ToString());
        }

        static public implicit operator ConstExpression(double num)
        {
            return new ConstExpression(num);
        }
    }
}
