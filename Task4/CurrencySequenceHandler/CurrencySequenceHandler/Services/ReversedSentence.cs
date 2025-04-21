using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySequenceHandler.Services
{
    /// <summary>
    /// Reverses the characters in a given sentence.
    /// </summary>
    public class ReversedSentence : ISentenceTransformer
    {
        /// <summary>
        /// Reverses the characters in the given sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string Transform(string sentence)
        {
            return new string([.. sentence.Reverse()]);
        }
    }
}
