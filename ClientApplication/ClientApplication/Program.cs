using System;
using System.Reflection;
using CaisseLibray1;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            CaisseLibrary.Caisse c = 

            Type objecttype = Type.GetTypeFromProgID("CaisseLibrary1.Class1");
            object objt = Activator.CreateInstance(objecttype);
            object c;
            c = objecttype.InvokeMember("GetMontant", BindingFlags.InvokeMethod, null, objt, null);
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
