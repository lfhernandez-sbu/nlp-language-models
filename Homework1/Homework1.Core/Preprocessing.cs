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
        public static ICollection<string> DumbTokenizer(ICollection<string> senteces)
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

        public static ICollection<string> DumbSentenceSegmentor(string[] corpus)
        {
            var sentences = new List<string>();
            string[] sentenceArray;
            foreach (var line in corpus)
            {
                sentenceArray = line.Split('.');
                foreach (var sentence in sentenceArray)
                    if (!sentence.Equals("\n") || !sentence.Equals(""))
                    {
                        sentences.Add(sentence);
                    }

            }
            return sentences;
        }

        public static string[] ReadFile(string _filePath)
        {
            string[] corpus = System.IO.File.ReadAllLines(_filePath);
            return corpus;
        }

    }
}
