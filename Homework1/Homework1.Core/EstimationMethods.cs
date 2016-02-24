using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Core
{
    public class EstimationMethods
    {
        public static double AbsoluteDiscounting(string precedingWord, string currentWord, List<string> tokens)
        {
            var bigram = new string[] { precedingWord, currentWord };
            var unigram = new string[] { precedingWord };
            return (CountNGgramOcurrence(bigram, tokens) - 0.5) / CountNGgramOcurrence(unigram, tokens);
        }


        public static double LaplaceSmoothing(string precedingWord, string currentWord, List<string> tokens)
        {
            var bigram = new string[] { precedingWord, currentWord };
            var unigram = new string[] { precedingWord };
            return ((double)CountNGgramOcurrence(bigram, tokens) + 1) / (CountNGgramOcurrence(unigram, tokens) + GetVocabulary(tokens).Count());
        }


        public static double MaximumLikelihoodEstimate(string precedingWord, string currentWord, List<string> tokens)
        {
            var bigram = new string[] { precedingWord, currentWord };
            var unigram = new string[] { precedingWord };
            return ((double)CountNGgramOcurrence(bigram, tokens) / CountNGgramOcurrence(unigram, tokens));
        }

        public static double KatzBackOffEstimate(string precedingWord, string currentWord, List<string> tokens)
        {
            Func<string, string, double> betaFunc = (x, y) =>
            {
                //var numerator = AbsoluteDiscounting(y);
                //var denominator;

                return 0.0;

            };
            return 0.0;
        }
        public static int CountNGgramOcurrence(string[] nGram, List<string> tokens)
        {
            var count = 0;
            for (var i = 0; i < tokens.Count - 1; i++)
            {
                var exists = true;

                for(var k = 0; k < nGram.Length; k++)
                {
                    if(!tokens[i + k].Equals(nGram[k]))
                    {
                        exists = false;
                        break;
                    }
                }
                if (exists)
                    count++;
            }
            return count;
        }

        public static List<string> GetVocabulary(List<string> corpus)
        {
            var wordTypes = corpus.Distinct().ToList();
            return wordTypes;
        }
    }
}
