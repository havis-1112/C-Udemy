using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableIEnumerator
{
    public class Program
    {
        public void Method()
        {
            List<string> list = new List<string>();
            IList<string> list2 = new List<string>();
            ICollection<string> list3 = new List<string>();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            /*
             
            public interface IEnumerator
            {
             object Current{get;}
             bool MoveNext();
             void Reset();
            }

             */

            IEnumerator<string> enumerator = list.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);

        }

    }
}
