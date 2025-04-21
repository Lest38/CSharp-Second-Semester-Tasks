using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencySequenceHandler
{
    /// <summary>
    /// Filters sentences based on the presence of currency.
    /// </summary>
    public class SentenceFilter : ISentenceFilter
    {
        private const string CurrencyPattern = @"(\$\s?\d+|\d+\s?руб\.?)";
        /// <summary>
        /// Checks if the given sentence contains currency.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public bool ContainsCurrency(string sentence)
        {
            return Regex.IsMatch(sentence, CurrencyPattern, RegexOptions.IgnoreCase);
        }
    }
}
