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
    public class ParametarExpression : MyExpression
    {
        private string name;

        public string Name { get => this.name; set => this.name = value; }

        public ParametarExpression(string name)
        {
            this.name = name;
       
        }
        public ParametarExpression() { }

        public override Func<List<Parametar>, double> Compile()
        {
            return (List<Parametar> parametar) => (parametar.FirstOrDefault(p => p.Name == this.name)).Value;
            
        }

        public override string GetString() => string.Format(this.name);

        public override XmlSchema GetSchema()
        {
            return null;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            //reader.ReadStartElement();
            this.name = reader.ReadElementContentAsString();
            //reader.ReadEndElement();
        }

        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.name);
        }

        public static implicit operator ParametarExpression(string text)
        {
            return new ParametarExpression(text);
        }

    }
}
