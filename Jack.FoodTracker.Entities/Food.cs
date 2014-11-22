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
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public double Sugars { get; set; }

        public double Fat { get; set; }

        public double Saturates { get; set; }

        public double Salt { get; set; }

        [Required]
        public FoodCategory Category { get; set; }

        public List<PresetMeal> PresetMeals { get; set; }

        public Food()
        {
        }

        public Food(string name, FoodCategory category, string description, int calories, double sugars, double fat, double saturates, double salt)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Calories = calories;
            this.Sugars = sugars;
            this.Fat = fat;
            this.Saturates = saturates;
            this.Salt = salt;
        }
    }
}
