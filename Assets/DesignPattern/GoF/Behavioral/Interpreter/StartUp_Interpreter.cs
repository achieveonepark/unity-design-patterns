using System;
using UnityEngine;

public class StartUp_Interpreter : MonoBehaviour
{
    private void Start()
    {
        var number = Interpreter.Parse("5 3 - 2 +");
        var result = number.Interpret();
    }
}