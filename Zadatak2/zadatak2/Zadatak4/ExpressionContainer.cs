using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadatak1;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Schema;


namespace Zadatak4
{
    [XmlRoot("Expression")]
    [Serializable]
    public class ExpressionContainer 
    {
        [XmlAttribute("Id")]
        public Guid Id { get; set; }
        [XmlElement("DataCreated")]
        public DateTime DateCreated { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Datamodified")]
        public DateTime DateModify { get; set; }
        [XmlElement("ConstExpression", typeof(ConstExpression))]
        [XmlElement("ParametarExpression", typeof(ParametarExpression))]
        [XmlElement("BinaryExpression", typeof(BinaryExpression))]
        public MyExpression Expression { get; set; }

        public ExpressionContainer() { }

        public ExpressionContainer(string name, MyExpression expression)
        {
            this.Id = Guid.NewGuid();
            this.DateCreated = DateTime.Now;
            this.Name = name;
            this.DateModify = DateTime.Now;
            this.Expression = expression;
        }
    }
}
