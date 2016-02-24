using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework1.Core;

namespace Homework1.App
{
    class LanguageModelBuilder
    {
        public string File { get; set; }

        public LanguageModelBuilder(string file)
        {
            File = file;
        }

        public void ParseFile()
        {
            Console.WriteLine("Reading Training File...");
            var text = Preprocessing.ReadFile(File);
            var corpus = Preprocessing.DumbSentenceSegmentor(text);
            var tokenizedCorpus = Preprocessing.DumbTokenizer(corpus.ToString());
            tokenizedCorpus = new List<string>(tokenizedCorpus.RemoveAll(string.IsNullOrEmpty));
        }

        public void ComputeProbability(List<string> tokens)
        {
            var mleDictionary = new Dictionary<string, double>();
            var lsDictionary = new Dictionary<string, double>();
            var adDictionary = new Dictionary<string, double>();

            for (var i = 0; i < tokens.Count; i++)
            {
                var mleProbability = EstimationMethods.MaximumLikelihoodEstimate(tokens[i], tokens[i+1], tokens);
                mleDictionary.Add(tokens[i] + tokens[i+1], mleProbability);
                var lsProbability = EstimationMethods.LaplaceSmoothing(tokens[i], tokens[i + 1], tokens);
                lsDictionary.Add(tokens[i] + tokens[i+1], lsProbability);
                var adProbability = EstimationMethods.AbsoluteDiscounting(tokens[i], tokens[i + 1], tokens);
                adDictionary.Add(tokens[i] + tokens[i+1], adProbability);
            }
        }
    }
}
