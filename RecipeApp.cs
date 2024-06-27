using poe_;
using System.Collections.Generic;
using System.Linq;

namespace poe_
{
    public class RecipeApp
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return recipes.OrderBy(r => r.Name).ToList();
        }

        public void ResetQuantities(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            recipe?.ResetQuantities();
        }

        public void ClearRecipeData(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipes.Remove(recipe);
            }
        }

        public List<Recipe> FilterRecipes(string ingredient, string foodGroup, double maxCalories)
        {
            return recipes.Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.Contains(ingredient))) &&
                (string.IsNullOrEmpty(foodGroup) || r.Ingredients.Any(i => i.FoodGroup.Contains(foodGroup))) &&
                r.CalculateTotalCalories() <= maxCalories).ToList();
        }
    }
}