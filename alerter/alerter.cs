using System;
using System.Diagnostics;

namespace AlerterSpace
{
    class Alerter
    {
        static int alertFailureCount = 0;
        static int networkAlertStub(float celcius)
        {
            float threshold = 400;
            Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);
            if (celcius > threshold)
            {
                return 500;
            }
            return 200;
        }
        static void alertInCelcius(float farenheit)
        {
            float celcius = (farenheit - 32) * 5 / 9;
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200)
            {
               
                alertFailureCount += 0;
            }
        }
        static void Main(string[] args)
        {
            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            Debug.Assert(alertFailureCount == 1);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);
            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
