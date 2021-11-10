﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Revard
    {
        private static int count = 0;
        public int ID { get; private set; }
        private string title;
        private string description;
        public string Title
        {
            get { return title; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Неверное наименование награды");
                if (value.Length>50)
                    throw new ArgumentException("Наименование награды должно быть короче 50 символов");
                title = value;
            }
        }
        public string Descripton
        {
            get { return description; }
            set
            {
                if (value.Length > 250)
                    throw new ArgumentException("Описание награды должно быть короче 250 символов");
                description = value;
            }
        }
       
        public Revard( string title, string description)
        {
            count++;
            ID = count;

            Title = title;
            Descripton = description;
        }
    }
}
