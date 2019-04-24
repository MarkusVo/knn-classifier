using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_CSHARP
{
    class Comparator : System.Collections.Generic.IComparer<Iris>
    {
        private Iris candidate;

        public Comparator(Iris candidate)
        {
            this.candidate = candidate;
        }
        
        public int Compare(Iris test1, Iris test2)
        {
            double dist1 = 0.0d;
            double dist2 = 0.0d;

            dist1 = Math.Sqrt(Math.Pow(test1.getSepalLength() - candidate.getSepalLength(), 2) +
                              Math.Pow(test1.getSepalWidth() - candidate.getSepalWidth(), 2) +
                              Math.Pow(test1.getPetalLength() - candidate.getPetalLength(), 2) +
                              Math.Pow(test1.getPetalWidth() - candidate.getPetalWidth(), 2));

            dist2 = Math.Sqrt(Math.Pow(test2.getSepalLength() - candidate.getSepalLength(), 2) +
                              Math.Pow(test2.getSepalWidth() - candidate.getSepalWidth(), 2) +
                              Math.Pow(test2.getPetalLength() - candidate.getPetalLength(), 2) +
                              Math.Pow(test2.getPetalWidth() - candidate.getPetalWidth(), 2));

            if (dist1 > dist2) return 1;
            if (dist1 < dist2) return -1;
            return 0;
        }
    }
}
