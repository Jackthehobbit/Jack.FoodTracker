using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.Entities
{
    public class Food
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public float Sugars { get; set; }

        public float Fat { get; set; }

        public float Saturates { get; set; }

        public float Salt { get; set; }

        public Food(string name, string description, int calories, float sugars, float fat, float saturates, float salt)
        {
            this.Name = name;
            this.Description = description;
            this.Calories = calories;
            this.Sugars = sugars;
            this.Fat = fat;
            this.Saturates = saturates;
            this.Salt = salt;
        }
    }
}
