using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework1.Core;

namespace Homework1.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading File...");
            var text = Preprocessing.ReadFile(@"E:\src\Homework1\train.txt");
            var corpus = Preprocessing.DumbSentenceSegmentor(text);
            var tokenizedCorpus = Preprocessing.DumbTokenizer(corpus);

            // running total of estimation method probabilities
            var mlep = 0.0;
            var lsp = 0.0;
            var adp = 0.0;

            var test = "A fat dog is a fat dog only when other fat dogs say he is a fat dog";
            var augmentedText = EstimationMethods.AddEdgeMarkers(test);


            Console.ReadKey();
        }
    }
}
