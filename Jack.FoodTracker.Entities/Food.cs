using DataAnnotationsExtensions;
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

        [Min(0)]
        public int Calories { get; set; }

        [Min(0)]
        public double Sugars { get; set; }

        [Min(0)]
        public double Fat { get; set; }

        [Min(0)]
        public double Saturates { get; set; }

        [Min(0)]
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

        public void Update(Food editedFood)
        {
            Name = editedFood.Name;
            Description = editedFood.Description;
            Category = editedFood.Category;
            Calories = editedFood.Calories;
            Sugars = editedFood.Sugars;
            Fat = editedFood.Fat;
            Saturates = editedFood.Saturates;
            Salt = editedFood.Salt;
        }
    }
}
