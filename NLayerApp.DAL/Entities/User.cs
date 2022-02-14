﻿namespace NLayerApp.DAL_.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public ICollection<Maze> Mazes { get; set; }
    }
}
