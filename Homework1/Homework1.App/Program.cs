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

            // running total of estimation method probabilities
            var mlep = 0.0;
            var lsp = 0.0;
            var adp = 0.0;

            var test = new List<string> {"A fat dog is a fat dog only when other fat dogs say he is a fat dog", ""};
            var augmentedText = Preprocessing.AddEdgeMarkers(test[0]);
            var tokenCorpus = augmentedText.ToLower().Split(' ').ToList();
            var bigramList = Preprocessing.GenerateBigramList(tokenCorpus);

            for (var i = 0; i < bigramList.Count; i++)
            {
                var mle = EstimationMethods.MaximumLikelihoodEstimate(bigramList[i], bigramList[i + 1], bigramList, test);
                var ls = EstimationMethods.LaplaceSmoothing(bigramList[i], bigramList[i + 1], bigramList, test);
                var ads = EstimationMethods.AbsoluteDiscounting(bigramList[i], bigramList[i + 1], bigramList, test);
                Console.WriteLine("P(" + bigramList[i] + " | " + bigramList[i + 1] + ")" + " = " + mle.ToString());
                mlep += Math.Log(mle, 2);
                lsp += Math.Log(ls, 2);
                adp += Math.Log(ads, 2);
            }
            mlep = Math.Pow(mlep, 2);
            lsp = Math.Pow(lsp, 2);
            adp = Math.Pow(adp, 2);
            Console.WriteLine("mle = " + mlep.ToString() + "\nls = " + lsp.ToString() + "\nabsolute discounting = " + adp.ToString());

            Console.ReadKey();
        }
    }
}
