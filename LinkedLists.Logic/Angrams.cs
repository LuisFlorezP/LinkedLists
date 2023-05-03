using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Logic
{
    public static class Angrams
    {
        public static Dictionary<string, int> Anagrams(List<string> sentencesSource, List<string> sentencesTarget)
        {
            var anagrams = new Dictionary<string, int>();
            for (int i = 0; i < sentencesSource.Count; i++)
            {
                if (sentencesSource[i].Length != sentencesTarget[i].Length)
                {
                    anagrams.Add($"\"{sentencesSource[i]}\" - \"{sentencesTarget[i]}\"", -1);
                    continue;
                }
                var source = sentencesSource[i].ToArray<char>();
                var target = sentencesTarget[i].ToArray<char>();
                Array.Sort(source);
                Array.Sort(target);
                Console.WriteLine("ARREGLO DE AMBAS PALABRAS:");
                for (int a = 0; a < source.Length; a++)
                {
                    Console.Write($"{source[a]}\t");
                }
                Console.WriteLine();
                for (int b = 0; b < target.Length; b++)
                {
                    Console.Write($"{target[b]}\t");
                }
                Console.WriteLine("\n");
                var countChanges = 0;
                var j = 0;
                var k = 0;
                while (j < source.Length)
                {
                    while (k < target.Length)
                    {
                        if (source[j] != target[k] || target[k] == '.')
                        {
                            k++;
                            continue;
                        }
                        target[k] = '.';
                        break;
                    }
                    if (k == target.Length)
                    {
                        countChanges++;
                    }
                    j++;
                    k = 0;
                }
                anagrams.Add($"\"{sentencesSource[i]}\" - \"{sentencesTarget[i]}\"", countChanges);
            }

            return anagrams;
        }
    }
}
