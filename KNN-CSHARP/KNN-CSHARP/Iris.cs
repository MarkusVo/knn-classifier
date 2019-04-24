using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_CSHARP
{
    public class Iris
    {
        private double sepalLength;
        private double sepalWidth;
        private double petalLength;
        private double petalWidth;

        private int irisClass;

        public Iris(double s1, double sw, double p1, double pw)
        {
            sepalLength = s1;
            sepalWidth = sw;
            petalLength = p1;
            petalWidth = pw;
        }

        public double getSepalLength()
        {
            return this.sepalLength;
        }

        public double getSepalWidth()
        {
            return this.sepalWidth;
        }

        public double getPetalLength()
        {
            return this.petalLength;
        }

        public double getPetalWidth()
        {
            return this.sepalWidth;
        }

        public int getIrisClass()
        {
            return this.irisClass;
        }

        public void setIrisClass(int irisClass)
        {
            this.irisClass = irisClass;
        }
    }
}
