using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing.Extension;
using Graphing.Interface;
using Graphing.Type;

namespace Graphing.Test
{
    public class TestClass
    {
        public static void Method()
        {
            var sample = 100;
            Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();
            for (var n = 0; n < 100; n++)
            {
                dic[n] = new Dictionary<int, int>();
                for (int i = 0; i < sample; i++)
                {
                    var x = RunTest(n);
                    if (dic[n].ContainsKey(x))
                        dic[n][x]++;
                    else dic[n][x] = 1;
                }
            }
        }

        public static int RunTest(int n)
        {
            IRandomGraph g = new RandomGraph(n);
            int c = 0;
            while (!g.IsConnected())
            {
                c++;
                g.NextEdge();
            }

            return c;
        }
    }
}
