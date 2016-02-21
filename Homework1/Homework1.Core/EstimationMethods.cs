using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Core
{
    public class EstimationMethods
    {
        public static double AbsoluteDiscounting(string precedingWord, string currentWord, List<string> bigramSet, List<string> corpus)
        {
            var bigram = Preprocessing.GenerateBigram(precedingWord, currentWord);
            return (CountNgramOcurrence(bigram, bigramSet) - 0.5) / CountNgramOcurrence(bigram, bigramSet);
        }


        public static double LaplaceSmoothing(string precedingWord, string currentWord, List<string>bigramSet, List<string> corpus)
        {
            var bigram = Preprocessing.GenerateBigram(precedingWord, currentWord);
            return (CountNgramOcurrence(bigram, bigramSet) + 1) / (CountNgramOcurrence(precedingWord, corpus) + GetVocabulary(corpus).Count());
        }


        public static double MaximumLikelihoodEstimate(string precedingWord, string currentWord, List<string> bigramSet, List<string> corpus)
        {
            var bigram = Preprocessing.GenerateBigram(precedingWord, currentWord);
            return CountNgramOcurrence(bigram, bigramSet) / CountNgramOcurrence(precedingWord, corpus);
        }


        public static int CountNgramOcurrence(string ngram, List<string> set)
        {
            var count = 0;
            foreach (var currentNgram in set)
            {
                if (currentNgram.Equals(ngram))
                {
                    count += 1;
                }
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
