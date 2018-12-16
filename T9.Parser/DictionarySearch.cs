using System;
using System.Collections.Generic;
using System.Text;

namespace T9.Parser
{
    /// <summary>
    /// Disctionary search using tree alogorithm
    /// </summary>
    public class DictionarySearch
    {
     
        #region Constructors
        public DictionarySearch()
        {
            RenderedKeys = new List<Word>();
        }
        #endregion

        #region Properties
        private List<Word> RenderedKeys { get; set; }

        public int Length { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// get encoded word
        /// </summary>
        /// <param name="stringLine">pass raw string line</param>
        /// <returns></returns>
        private string[] GetEncodeWord(string stringLine)
        {
            List<string> encodedList = new List<string>();
            string previous = string.Empty;
            string current = string.Empty;
            foreach (var ch in stringLine)
            {
                if (T9Dictionary.Instance.Keypad.ContainsKey(ch))
                {
                    current = T9Dictionary.Instance.Keypad[ch].ToString();
                    if ((previous.Contains(current) || current.Contains(previous)) && previous != string.Empty)
                    {
                        encodedList.Add(" ");
                    }

                    encodedList.Add(current);

                }

                previous = current;
            }

            return encodedList.ToArray();
        }
         
         /// <summary>
         /// insert words 
         /// </summary>
         /// <param name="stringLine">line to be inserted</param>
        private void InsertLine(string stringLine)
        {
            stringLine = stringLine == null ? string.Empty : stringLine.ToLower();

            //encode the word
            string[] encodedWord = GetEncodeWord(stringLine);

            //if encoded array is empty, that means there was no  match from keymap hence exit.
            if (encodedWord.Length == 0)
                return;

            Word word = new Word(stringLine, encodedWord);

            RenderedKeys.Add(word);
          
        }

        /// <summary>
        /// add error message instead of the case
        /// </summary>
        /// <param name="message"></param>
        private void AddErrorMessage(string message)
        {
            RenderedKeys.Add(new Word(message, new string[] { message }));
            Length++;
        }

        /// <summary>
        /// Insert words from a file
        /// </summary>
        /// <param name="rawString">provide raw string extracted from the file</param>
        public void InsertFromRaw(string rawString)
        {
            //reset length incase if manual InsertLine was previously used.
            Length = 0;

            //if string is empty or null no need to process.
            if (string.IsNullOrEmpty(rawString))
            {
                AddErrorMessage("Empty string");
                return;
            }
            string[] lines = rawString.ToLower().Split(new[] { '\n' });

            //first line is always length 
            int length = 0;
            int.TryParse(lines[0],out length);
            //if length is not provided, no need to loop through the data
            if (length == 0)
            {
                AddErrorMessage("Length not found");
                return;
            }

            Length = length;
            //reuse this for another purpose. i.e to find out end of file.
            length = lines.Length; 
            //if last line is empty string means its end of file, don't process it.
            if (lines[length - 1] == string.Empty)
            {
                length--;
            }

            if (lines.Length < 2)
            {
                AddErrorMessage("Length provided but data missing");
                return;
            }

            //exit if length doesn't match with the actual size
            if (Length != length-1)
            {
                AddErrorMessage("Invalid length");
                return;
            }
           
            //starting index of loop from 1 as index 0 has length of raw string
            for (int i = 1; i <= Length; i++)
            {
                InsertLine(lines[i]);
            }
        }

        /// <summary>
        /// Overridden ToString to get the cases
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder wordBuilder = new StringBuilder();

            for (int i = 0; i < this.Length;i++)
            {
                //process only available strings
                if (i >= RenderedKeys.Count)
                    break;
                Word word = RenderedKeys[i];
                string formatedCase = string.Format("Case #{0}: {1}",i+1,word.ToString());

                wordBuilder.Append(formatedCase).Append(Environment.NewLine);
            }

            return wordBuilder.ToString();
            
        }
        
        #endregion

    }
}
