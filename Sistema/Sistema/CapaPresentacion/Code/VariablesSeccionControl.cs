using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VariablesSeccionControl
/// </summary>
public class VariablesSeccionControl
{
    public VariablesSeccionControl()
    {
    }

    public static T Lee<T>(string variable)
    {
        object valor = HttpContext.Current.Session[variable];
        if (valor == null)
            return default(T);
        else
            return ((T)valor);
    }
    public static void Escribe(string variable, object valor)
    {
        HttpContext.Current.Session[variable] = valor;
    }
}