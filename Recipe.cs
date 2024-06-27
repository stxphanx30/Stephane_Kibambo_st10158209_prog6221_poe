using poe_;
using System;
using System.Collections.Generic;
using System.Linq;

namespace poe_
{
    /// <summary>
    /// in this class is basically the class where most of everything of the project will happpen here proceesing methods to display
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    class Recipe
    {
        public string Name { get; set; }
        // List to store ingredients
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        // List to store steps
        private List<string> stepDescriptions = new List<string>();


        /// <summary>
        /// method to get therecipe detail from the user input
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void GetRecipeDetails()
        {
            Console.WriteLine("Please enter the name of the recipe:");
            Name = Console.ReadLine();

            // Get ingredients from user input
            GetIngredients();

            // Get steps from user input
            GetSteps();
        }


        /// <summary>
        /// method to get the ingredients details from the user input
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void GetIngredients()
        {
            Console.WriteLine("Please enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories = double.Parse(Console.ReadLine());
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }
        }

        /// <summary>
        /// method to get the step from the user input
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void GetSteps()
        {
            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter description for step {i + 1}:");
                stepDescriptions.Add(Console.ReadLine());
            }
        }


        /// <summary>
        /// method to display the recipe 
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < stepDescriptions.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {stepDescriptions[i]}");
            }
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}");
        }


        /// <summary>
        /// method to calculate the total calorie of the recipe
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories + ingredient.Quantity);
        }


        /// <summary>
        /// methot to scale the recipe quantity this is the proceccing method of the scalerecipe method  in the recipeapp.cs file
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        /// <summary>
        /// methot to reset the quantity this is the proceccing method of the resetquantity method  in the recipeapp.cs file
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        /// <summary>
        /// methot to clear the data processing method for clear data metho in the recipeapp.cs file
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void ClearData()
        {
            Ingredients.Clear();
            stepDescriptions.Clear();
        }
    }
}