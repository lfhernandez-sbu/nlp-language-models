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
            var bigram = GenerateBigram(precedingWord, currentWord);
            return (CountNgramOcurrence(bigram, bigramSet) - 0.5) / CountNgramOcurrence(bigram, bigramSet);
        }


        public static double LaplaceSmoothing(string precedingWord, string currentWord, List<string>bigramSet, List<string> corpus)
        {
            var bigram = GenerateBigram(precedingWord, currentWord);
            return (CountNgramOcurrence(bigram, bigramSet) + 1) / (CountNgramOcurrence(precedingWord, corpus) + GetVocabulary(corpus).Count());
        }


        public static double MaximumLikelihoodEstimate(string precedingWord, string currentWord, List<string> bigramSet, List<string> corpus)
        {
            var bigram = GenerateBigram(precedingWord, currentWord);
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


        public static string GenerateBigram(string precedingWord, string currentWord)
        {
            var bigram = precedingWord + " " + currentWord;
            return bigram;
        }


        public static ICollection<string> GenerateBigramList(List<string> corpus)
        {
            var bigramSet = new List<string>();
            for (int i = 0; i < corpus.Count - 1; i++)
            {
                var currentBigram = corpus[i] + " " + corpus[i + 1];
                bigramSet.Add(currentBigram);
            }
            return bigramSet;
        }


        public static string AddEdgeMarkers(string bigramSet)
        {
            return "<s>" + bigramSet + "</s>";
        }


        public static ICollection<string> GetVocabulary(List<string> corpus)
        {
            var wordTypes = corpus.Distinct().ToList();
            return wordTypes;
        }
    }
}
