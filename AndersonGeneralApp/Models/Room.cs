﻿namespace AndersonGeneralApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool Is_occupied { get; set; }
        public bool Is_cleaned { get; set; }
    }
}
