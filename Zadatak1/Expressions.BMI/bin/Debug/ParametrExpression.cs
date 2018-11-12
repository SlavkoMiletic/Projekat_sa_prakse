using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace zadatak1
{
    
    class ParametrExpression : MyExpression
    {
        private string name;
        

        public ParametrExpression(string name)
        {
            this.name = name;
       
        }       

        public override Func<List<Parametar>, double> Compile()
        {
            return (List<Parametar> parametar) => (parametar.FirstOrDefault(p => p.Name == this.name)).Value;
            
        }

        public override string GetString(MyExpression exp) => string.Format(this.name);

        public static implicit operator ParametrExpression(string text)
        {
            return new ParametrExpression(text);
        }

    }
}
