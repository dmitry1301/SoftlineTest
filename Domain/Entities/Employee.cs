using Domain.Entities;
using System;

namespace Domain
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime Year { get; set; }
        public string Characteristic { get; set; }
        public bool Decree { get; set; }
    }
}
