using System.Reflection;
using TemperatureConverterLibrary;

namespace HomeTasks_Pro_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char degreeSymbol = '\u00B0';

            Assembly assembly = Assembly.Load("TemperatureConverterLibrary");

            Type type = assembly.GetType("TemperatureConverterLibrary.TemperatureConverter");

            object obj = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod("FahrenheitToCelsius");

            Console.WriteLine($"32 {degreeSymbol}F == {methodInfo.Invoke(obj, new object[] { 32 })} {degreeSymbol}C");

            methodInfo = type.GetMethod("CelsiusToFahrenheit");

            Console.WriteLine($"32 {degreeSymbol}C == {methodInfo.Invoke(obj, new object[] { 32 })} {degreeSymbol}F");


        }
    }
}