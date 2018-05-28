using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard {
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people) {
            People = new List<Person>();
            foreach (List<string> personInformation in people)
            {
                if (personInformation == people[0])
                {
                    //Do nothing, next
                }
                else
                {
                People.Add(new Person(int.Parse(personInformation[0]), personInformation[1], personInformation[2], new DateTime(long.Parse(personInformation[3]))));
                }
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
            DateTime oldestDate = People.Select(individual => individual.Dob).Min();
            List<Person> oldestPeople = People.Where(individual => individual.Dob == oldestDate).ToList();
            return oldestPeople;
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {
            string retrievedString = People.Find(person => person.Id == id).ToString();
            return retrievedString;  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            List<Person> orderedList = People.OrderBy(person => person.Surname).ToList();  //-- return result here
            return orderedList;
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            int numberOfPeople = People.Select(person => person.Surname).Where(surname => surname.StartsWith(searchTerm, !caseSensitive, null)).Count();
            return numberOfPeople;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> orderedBirthdayCountList = new List<string>();
            People.OrderBy(person => person.Dob);
            People.GroupBy(individual => individual.Dob).ToList();
            //Something
            return orderedBirthdayCountList;  //-- return result here
        }
    }
}