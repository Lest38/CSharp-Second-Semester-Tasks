using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySequenceHandler.Services
{
    /// <summary>
    /// Interface for transforming sentences.
    /// </summary>
    public interface ISentenceTransformer
    {
        /// <summary>
        /// Transforms the given sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        string Transform(string sentence);
    }
}
