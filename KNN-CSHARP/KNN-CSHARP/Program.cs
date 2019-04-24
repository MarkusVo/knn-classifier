using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KNN_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            String file = "../../iris.data";
            List<Iris> allIris = new List<Iris>();
            List<Iris> irisSetosa = new List<Iris>();
            List<Iris> irisVersicolor = new List<Iris>();
            List<Iris> irisVerginica = new List<Iris>();


            try
            {
                StreamReader sr = new StreamReader(file);
                int i = 0;
                string line;


                while ((line = sr.ReadLine()) != null)
                {

                    String[] stringArr = line.Split(',');
                    allIris.Add(new Iris(double.Parse(stringArr[0], NumberStyles.Any),
                        double.Parse(stringArr[1], CultureInfo.InvariantCulture),
                        double.Parse(stringArr[2], CultureInfo.InvariantCulture),
                        double.Parse(stringArr[3], CultureInfo.InvariantCulture)));


                    switch (stringArr[4])
                    {
                        case "Iris-setosa":
                            allIris[i].setIrisClass(1);
                            break;
                        case "Iris-versicolor":
                            allIris[i].setIrisClass(2);
                            break;
                        case "Iris-virginica":
                            allIris[i].setIrisClass(3);
                            break;
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.Write(allIris.Count);
                Console.Write(e.Message, e.Data, e.StackTrace);
                Console.ReadLine();
            }

            foreach (Iris Iris in allIris)
            {
                int s = Iris.getIrisClass();

                switch (s)
                {
                    case 1:
                        irisSetosa.Add(Iris);
                        break;
                    case 2:
                        irisVersicolor.Add(Iris);
                        break;
                    case 3:
                        irisVerginica.Add(Iris);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < allIris.Count / 15; i++)
            {
                List<Iris> learnData = new List<Iris>();
                List<Iris> testData = new List<Iris>();

                var classification = new int[allIris.Count - 15, 2];

                foreach (Iris Iris in allIris)
                {
                    testData.Add(Iris);
                }

                for (int j = 0; j < 5; j++)
                {
                    learnData.Add(irisSetosa[i * 5 + j]);
                    testData.Remove(irisSetosa[i * 5 + j]);

                    learnData.Add(irisVersicolor[i * 5 + j]);
                    testData.Remove(irisVersicolor[i * 5 + j]);

                    learnData.Add(irisVerginica[i * 5 + j]);
                    testData.Remove(irisVerginica[i * 5 + j]);
                }


                for (int j = 0; j < testData.Count; j++)
                {
                    Iris temp = testData[j];
                    IComparer<Iris> comp = new Comparator(temp);

                    learnData.Sort(comp);

                    int[] common = new int[3];
                    for (int k = 0; k < 3; k++)
                    {
                        common[k] = 0;
                    }

                    for (int k = 0; k < 3; k++)
                    {
                        common[learnData[k].getIrisClass() - 1]++;
                    }

                    int mostCommon = 0;
                    int appearance = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        if(common[k] > appearance)
                        {
                            appearance = common[k];
                            mostCommon = k;
                        }
                    }

                    classification[j, 0] = temp.getIrisClass();
                    classification[j, 1] = mostCommon;
                }

                //Make use of jagged Array -> Thank you Microsoft cuz' this looks a hundret times more ugly than java
                int[][] confusion = new int[3][] {new int[2], new int[2], new int[2]};

                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        confusion[k][l] = 0;
                    }
                }

                foreach (int[] x in classification)
                {
                    switch (x[0])
                    {
                        case 1:
                            confusion[0][x[1]]++;
                            break;

                        case 2:
                            confusion[1][x[1]]++;
                            break;

                        case 3:
                            confusion[2][x[1]]++;
                            break;
                    }
                }

                double right = 0;
                double wrong = 0;
                double accuracy = 0;

                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        Console.Write(confusion[k][l] + " ");
                        Console.Read();

                        if (k == l)
                        {
                            right += confusion[k][l];
                        }
                        else
                        {
                            wrong += confusion[k][l];
                        }
                        Console.WriteLine();
                        Console.Read();

                    }
                }

                accuracy = right / (right + wrong);

                Console.WriteLine("Accuracy:" + accuracy);
            }

            Console.ReadLine();

        }

    }
}
