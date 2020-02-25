using GeometricCalculators;
using System;
using System.Collections.Generic;

namespace Calc
{
    public class CalcExecutor
    {
       private Dictionary<string, ShapeCalculator> calculators
                                                   = new Dictionary<string, ShapeCalculator>();

        public void AddCalculator(ShapeCalculator calculator)
        {
            if (!calculators.ContainsKey(calculator.Name))
            {
                calculators.Add(calculator.Name, calculator);
            }
        }

        public Dictionary<string, ShapeCalculator> GetAll()
        {
            return calculators;
        }

        public ShapeCalculator GetByName(string name)
        {
            if (calculators.ContainsKey(name))
            {
                return calculators[name];
            }

            return null;
        }
    }
}
