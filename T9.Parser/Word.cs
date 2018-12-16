using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9.Parser
{
    /// <summary>
    /// Class to map the words with keys
    /// </summary>
    public class Word
    {

        #region Constructors
        /// <summary>
        /// Word constructor to create the word
        /// </summary>
        /// <param name="val">Pass raw string word</param>
        /// <param name="keys">Encoded word</param>
        public Word(string val,string[] keys)
        {
            Value = val;
            Keys = keys;
        }
        #endregion

        #region Properties
        public string Value { get; private set; }
  
        public string[] Keys { get; private set; }
        #endregion

        #region Overrides

        /// <summary>
        /// Overridden ToString to get the keys
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("",Keys);
        }
        #endregion
    }
}
