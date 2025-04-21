using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySequenceHandler.Services
{
    /// <summary>
    /// Interface for filtering sentences based on the presence of currency.
    /// </summary>
    public interface ISentenceFilter
    {
        /// <summary>
        /// Checks if the given sentence contains currency.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        bool ContainsCurrency(string sentence);
    }
}
