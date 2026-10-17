
//using System.Diagnostics;
using UnityEngine;
public static class Debugger
{
    //[Conditional("DEBUG")]
    public static void Log(string message)
    {
        //System.Diagnostics.Debug.WriteLine(message);
        Debug.Log(message);
    }
}
