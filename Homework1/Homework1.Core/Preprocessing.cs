using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework1.Core
{
    public static class Preprocessing
    {
        public static List<string> DumbSentenceSegmentor(string corpus)
        {
            corpus = corpus.Replace('\n', ' ');
            var sentences = new List<string>();
            var sentenceArray = corpus.Split('.');

            foreach (var sentence in sentenceArray)
            {
                if (!string.IsNullOrWhiteSpace(sentence))
                {
                    sentences.Add(sentence);
                }
            }
            return sentences;
        }


        public static List<string> DumbTokenizer(string sentence)
        {
            var tokens = new List<string>();
            string[] tokenArray;
            tokenArray = Regex.Split(sentence.AddEdgeMarkers(), @"\s+");
            tokens.AddRange(tokenArray);
            return tokens;
        }


        public static string[] GenerateBigram(string precedingWord, string currentWord)
        {
            var bigram = new string[] { precedingWord, currentWord };
            return bigram;
        }


        public static List<string> GenerateBigramList(List<string> corpus)
        {
            var bigramList = new List<string>();
            for (var i = 0; i < corpus.Count - 1; i++)
            {
                var currentBigram = corpus[i] + " " + corpus[i + 1];
                bigramList.Add(currentBigram);
            }
            return bigramList;
        }


        public static string AddEdgeMarkers(this string sentence)
        {
            return "<s> " + sentence + " </s>";
        }


        public static string ReadFile(string _filePath)
        {
            return File.ReadAllText(_filePath);
        }
    }
}
