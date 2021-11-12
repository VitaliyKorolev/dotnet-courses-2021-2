using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Task1
{
    public class User
    {
        private static int count = 0;
        public int ID { get; set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (today.Month < BirthDate.Month || (today.Month == BirthDate.Month && today.Day < BirthDate.Day)) age--;
                return age;
            }
        }
        public IList<Revard> Rev { get;  set; }
        public string RevardsAsString
        {
            get
            {
                string[] str = new string[Rev.Count];
                for(int i=0; i<Rev.Count; i++)
                {
                    str[i] = Rev[i].Title;
                }
                string s = String.Join(", ", str);
                return s;
            }
        }
        public User( DateTime date, string name, string lastname)
        {
            BirthDate = date;
            if (date > DateTime.Now.Date || this.Age > 150) { throw new Exception("Недопустимая дата рождения"); }
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Неверное имя пользователя");

            if (String.IsNullOrEmpty(lastname))
                throw new ArgumentException("Неверная фамилия пользователя");

            count++;
            ID = count;

            Rev = new BindingList<Revard>();
            
            Name = name;
            LastName = lastname;
            
        }
    }
}
