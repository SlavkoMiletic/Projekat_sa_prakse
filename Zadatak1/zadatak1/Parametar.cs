using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    public class Parametar
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Parametar(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
