namespace poe_
{
    /// <summary>
    /// this class just storing the ingredient details
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public double Calories { get; }
        public string FoodGroup { get; }
        private double originalQuantity;

        // Constructor to initialize the ingredient
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            originalQuantity = quantity;
        }

        /// <summary>
        /// this method saves the original values of the quantity collection processing method also for reset quantity in recipe.cs and recipeapp.cs files 
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }
}