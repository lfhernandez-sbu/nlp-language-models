using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework1.Core
{
    public class Preprocessing
    {
        public static List<string> DumbTokenizer(List<string> senteces)
        {
            var tokens = new List<string>();
            string[] tokenArray;
            foreach (var sentece in senteces)
            {
                tokenArray = sentece.Split(' ');
                foreach (var word in tokenArray)
                {
                    if (!word.Equals("\n") || !word.Equals(""))
                    {
                        tokens.Add(word);
                    }
                }
            }
            return tokens;
        }

        public static List<string> DumbSentenceSegmentor(string[] corpus)
        {
            var sentences = new List<string>();
            foreach (var line in corpus)
            {
                var sentenceArray = line.Split('.');
                foreach (var sentence in sentenceArray)
                    if (!sentence.Equals("\n") || !sentence.Equals(""))
                    {
                        sentences.Add(sentence);
                    }
            }
            return sentences;
        }


        public static string GenerateBigram(string precedingWord, string currentWord)
        {
            var bigram = precedingWord + " " + currentWord;
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


        public static string AddEdgeMarkers(string bigramSet)
        {
            return "<s> " + bigramSet + " </s>";
        }


        public static string[] ReadFile(string _filePath)
        {
            string[] corpus = File.ReadAllLines(_filePath);
            return corpus;
        }
    }
}
