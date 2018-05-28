using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {

            for (int line = 0; line < data.Count; line++)
            {
                for (int dataBlock = 0; dataBlock < data[line].Count; dataBlock++)
                {
                   data[line][dataBlock] = data[line][dataBlock].Trim();
                }
            }
            return data;
        }

        /// <summary>
        /// Adds quotes to each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> AddQuotes(List<List<string>> data) {

            for (int line = 0; line < data.Count; line++)
            {
                for (int dataBlock = 0; dataBlock < data[line].Count; dataBlock++)
                {
                    data[line][dataBlock] = ("\"" + data[line][dataBlock].Trim() + "\"");
                }
            }
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            for (int line = 0; line < data.Count; line++)
            {
                for (int dataBlock = 0; dataBlock < data[line].Count; dataBlock++)
                {
                    data[line][dataBlock] = data[line][dataBlock].Trim('\"', '\'');
                }
            }
            return data;
        }

    }
}