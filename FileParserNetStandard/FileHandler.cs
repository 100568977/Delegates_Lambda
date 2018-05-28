using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// C:\Users\kbke2\Desktop\TAFE 2018\Dev Ops\Week 7\Files
        public List<string> ReadFile(string filePath)
        {
            List<string> userDetails = File.ReadAllLines(filePath).ToList();
            return userDetails;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            File.Delete(filePath);
            foreach(List<string> user in rows)
            {
                for (int i = 0; i < user.Count; i++)
                {
                    if (i == (user.Count - 1))
                    {
                        File.AppendAllText(filePath, user[i]);
                    }
                    else
                    {
                    File.AppendAllText(filePath, (user[i] + delimeter));
                    }
                }
                File.AppendAllText(filePath, Environment.NewLine);
            }
        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter)
        {
            List<List<string>> delimeteredList;
            delimeteredList = data.Select(line => line.Split(delimeter).ToList()).ToList();
            return delimeteredList;
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            return data.Select(r => r.Split(',').ToList()).ToList();
            //List<List<string>> commaSeperatedList;
            //commaSeperatedList = data.Select(line => line.Split(',').ToList()).ToList();
            //return commaSeperatedList;  //-- return result here
            //Single quotes = character
        }
    }
}