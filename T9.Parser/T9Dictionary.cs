using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9.Parser
{
    /// <summary>
    /// singleton T9 dictionary class to get the key map
    /// </summary>
    public sealed class T9Dictionary 
    {

        #region Variables
        private static T9Dictionary instance = null;
        #endregion 
        #region Constructor
        private T9Dictionary()
        {
            Keypad = GetT9Dictionary();
        }
        #endregion

        #region Properties

        public static T9Dictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T9Dictionary();
                }
                return instance;
            }
        }
        /// <summary>
        /// get T9 Keypad mapped with the alphabets
        /// </summary>
        public Dictionary<char, int> Keypad
        {
            get;private set;
        }
        #endregion

        #region Methods
        private Dictionary<char, int> GetT9Dictionary()
        {
            Dictionary<char, int> t9Dictionary = new Dictionary<char, int>();

            t9Dictionary.Add('a', 2);
            t9Dictionary.Add('b', 22);
            t9Dictionary.Add('c', 222);
            t9Dictionary.Add('d', 3);
            t9Dictionary.Add('e', 33);
            t9Dictionary.Add('f', 333);
            t9Dictionary.Add('g', 4);
            t9Dictionary.Add('h', 44);
            t9Dictionary.Add('i', 444);
            t9Dictionary.Add('j', 5);
            t9Dictionary.Add('k', 55);
            t9Dictionary.Add('l', 555);
            t9Dictionary.Add('m', 6);
            t9Dictionary.Add('n', 66);
            t9Dictionary.Add('o', 666);
            t9Dictionary.Add('p', 7);
            t9Dictionary.Add('q', 77);
            t9Dictionary.Add('r', 777);
            t9Dictionary.Add('s', 7777);
            t9Dictionary.Add('t', 8);
            t9Dictionary.Add('u', 88);
            t9Dictionary.Add('v', 888);
            t9Dictionary.Add('w', 9);
            t9Dictionary.Add('x', 99);
            t9Dictionary.Add('y', 999);
            t9Dictionary.Add('z', 9999);
            t9Dictionary.Add(' ', 0);
            return t9Dictionary;
        }
        #endregion
    }
}
