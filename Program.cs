using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        { 
            
            foreach (string element in UserCollection.Power())
            {
                Console.WriteLine(element);
            }

            IEnumerable enumerable = UserCollection.Power();

            IEnumerator enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                String element = enumerator.Current as String;

                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
