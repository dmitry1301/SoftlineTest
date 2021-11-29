using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftlineTest.Models
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        [Display(Name="ФИО")]
        public string Name { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        [Display(Name = "Год рождения")]
        public DateTime Year { get; set; }
        [Display(Name = "Характеристика")]
        public string Characteristic { get; set; }
        [Display(Name = "Декрет")]
        public bool Decree { get; set; }
    }
}
