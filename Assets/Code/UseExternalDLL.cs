using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculator.Equations;
using UnityEngine;


class UseExternalDLL : MonoBehaviour
{
    private void Hello()
    {
        Sums sum = new Sums();
        float mult = sum.Multiply(4, 5);
        float plus = sum.Add(4, 5);
        float min = sum.Subtract(4, 5);
        float div = sum.Divide(4, 5);
    }
    
}

