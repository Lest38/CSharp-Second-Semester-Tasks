using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencySequenceHandler
{
    /// <summary>
    /// Extracts sentences from a given text.
    /// </summary>
    public class SentenceExtractor : ISentenceExtractor
    {
        /// <summary>
        /// Extracts sentences from the given text using regex.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<string> ExtractSentences(string text)
        {
            return Regex.Split(text, @"(?<=[.!?])")
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();
        }
    }
}
