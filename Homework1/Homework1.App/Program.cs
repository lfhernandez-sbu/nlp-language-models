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
            Console.ReadKey();
        }
    }
}
