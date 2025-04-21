using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySequenceHandler
{
    /// <summary>
    /// Interface for extracting sentences from a given text.
    /// </summary>
    public interface ISentenceExtractor
    {
        /// <summary>
        /// Extracts sentences from the given text using regex.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        List<string> ExtractSentences(string text);
    }
}
