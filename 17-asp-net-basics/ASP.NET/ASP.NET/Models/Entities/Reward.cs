using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Reward
    {
        private static int count = 0;
        public int ID { get;  set; }
        private string title;
        private string description;

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(50)]
        public string Title
        {
            get { return title; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Неверное наименование награды");
                if (value.Length > 50)
                    throw new ArgumentException("Наименование награды должно быть короче 50 символов");
                title = value;
            }
        }
        [MaxLength(250)]
        public string Description
        {
            get { return description; }
            set
            {
                if (value?.Length > 250)
                    throw new ArgumentException("Описание награды должно быть короче 250 символов");
                description = value;
            }
        }

        public Reward(string title, string description)
        {
            count++;
            ID = count;

            Title = title;
            Description = description;
        }
        public Reward()
        {

        }
        public Reward(int id, string title, string description)
        {
            count = id;
            ID = id;
            Title = title;
            Description = description;

        }
    }
}
