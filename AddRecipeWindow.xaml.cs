using poe_;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace poe_
{
    public partial class AddRecipeWindow : Window
    {
        private RecipeApp recipeApp;
        private Recipe newRecipe;

        public AddRecipeWindow(RecipeApp app)
        {
            InitializeComponent();
            recipeApp = app;
            newRecipe = new Recipe();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text;
            if (double.TryParse(IngredientQuantityTextBox.Text, out double quantity) &&
                double.TryParse(IngredientCaloriesTextBox.Text, out double calories))
            {
                string unit = IngredientUnitTextBox.Text;
                string foodGroup = IngredientFoodGroupTextBox.Text;
                newRecipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                IngredientsListBox.Items.Add($"{name} ({quantity} {unit}, {calories} cal, {foodGroup})");
                IngredientNameTextBox.Clear();
                IngredientQuantityTextBox.Clear();
                IngredientUnitTextBox.Clear();
                IngredientCaloriesTextBox.Clear();
                IngredientFoodGroupTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid quantity and calorie values.");
            }
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            newRecipe.Name = RecipeNameTextBox.Text;
            recipeApp.AddRecipe(newRecipe);
            this.Close();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Or any other color for active text
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name.Replace("TextBox", ""); // Restores placeholder
                textBox.Foreground = Brushes.Gray; // Or the initial placeholder color
            }
        }
    }
}