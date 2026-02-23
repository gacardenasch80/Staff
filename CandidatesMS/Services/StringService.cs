using CandidatesMS.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IStringService
    {
        double LevenshteinDistance(string stringA, string stringB);
    }

    public class StringService : IStringService
    {
        public double LevenshteinDistance(string stringA, string stringB)
        {
            List<string> setA = new List<string>();
            List<string> setB = new List<string>();

            for (int i = 0; i < stringA.Length - 1; ++i) // Substring of the first string
                setA.Add(stringA.Substring(i, 2));
            
            for (int i = 0; i < stringB.Length - 1; ++i) // Substring of the second string
                setB.Add(stringB.Substring(i, 2));

            IEnumerable<string> intersection = setA.Intersect(setB, StringComparer.InvariantCultureIgnoreCase); // Compare 2 sets of substrings to find the match

            return (2.0 * intersection.Count()) / (setA.Count + setB.Count); // Return a value from 0 to 1, the match level
        }
    }
}
