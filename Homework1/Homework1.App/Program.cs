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
            //var text = Preprocessing.ReadFile(@"C:\src\nlp-language-models\Homework1\train.txt");
            //var corpus = Preprocessing.DumbSentenceSegmentor(text);
            //var tokenizedCorpus = Preprocessing.DumbTokenizer(corpus);
            //tokenizedCorpus = new List<string>(tokenizedCorpus.RemoveAll(string.IsNullOrEmpty));
            
            var test = "A fat dog is a fat dog only when other fat dogs say he is a fat dog";
            var tokens = Preprocessing.DumbTokenizer(test);

            for (var i = 0; i < tokens.Count - 1; i++)
            {
                var mle = EstimationMethods.MaximumLikelihoodEstimate(tokens[i], tokens[i + 1], tokens);
                var ls = EstimationMethods.LaplaceSmoothing(tokens[i], tokens[i + 1], tokens);
                var ads = EstimationMethods.AbsoluteDiscounting(tokens[i], tokens[i + 1], tokens);
                Console.WriteLine("P(" + tokens[i] + " | " + tokens[i + 1] + ")" + " = " + mle.ToString());
            }
            Console.ReadKey();
        }
    }
}
