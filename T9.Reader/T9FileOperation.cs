using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9.Reader
{
    public static class T9FileOperation
    {
        #region Constants
        private const string SMALL_FILE = "SmallFile";
        private const string LARGE_FILE = "LargeFile";
        private const string OUTPUT_PATH = "OutputPath";
        #endregion

        #region Properties
        public static string FilePath {
            get
            {
                return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            }
        }

        public static string OutputPath
        {
            get { return string.Format("{0}\\{1}", FilePath, System.Configuration.ConfigurationManager.AppSettings[OUTPUT_PATH]); }
        }
        #endregion
        #region Methods

        /// <summary>
        /// Get small file contents
        /// </summary>
        /// <returns></returns>
        public static string GetSmallFileData()
        {
            string filePath = string.Format("{0}\\{1}", FilePath, System.Configuration.ConfigurationManager.AppSettings[SMALL_FILE]);

            return GetDataFromFile(filePath);
        }

        /// <summary>
        /// Get large file contents
        /// </summary>
        /// <returns></returns>
        public static string GetLargeFileData()
        {
            string filePath = string.Format("{0}\\{1}", FilePath, System.Configuration.ConfigurationManager.AppSettings[LARGE_FILE]);

            return GetDataFromFile(filePath);
        }

        /// <summary>
        /// Save the output file
        /// </summary>
        /// <param name="isLarge">pass true if it is large file</param>
        /// <param name="contents">output contents</param>
        public static bool SaveOutputFile(bool isLarge,string contents)
        {
            string filePath = string.Format("{0}\\small.out", OutputPath);
            if (isLarge)
                filePath = string.Format("{0}\\large.out", OutputPath);

            try
            {

                if (!Directory.Exists(OutputPath))
                    Directory.CreateDirectory(OutputPath);

                File.WriteAllText(filePath, contents);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// get file data
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static string GetDataFromFile(string filePath)
        {
            string fileContents = string.Empty;
            
            using (var reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
            {
               fileContents = reader.ReadToEnd();
            }

            return fileContents;
        }
        #endregion
    }
}
