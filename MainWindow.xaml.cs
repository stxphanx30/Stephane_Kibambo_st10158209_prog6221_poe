using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace poe_
{
    public partial class MainWindow : Window
    {
        private RecipeApp recipeApp;

        public MainWindow()
        {
            InitializeComponent();
            recipeApp = new RecipeApp();
        }
        private void LoadRecipes()
        {
            var recipes = recipeApp.GetRecipes();
            RecipeListBox.ItemsSource = recipes;
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeApp);
            addRecipeWindow.ShowDialog();
            LoadRecipes();
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            RecipeListBox.Items.Clear();
            foreach (var recipe in recipeApp.GetRecipes())
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
            {
                ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow(recipeApp, selectedRecipe);
                scaleRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }

        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipe = RecipeListBox.SelectedItem.ToString();
                recipeApp.ResetQuantities(selectedRecipe);
                MessageBox.Show("The quantities have been reset.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset quantities.");
            }
        }

        private void ClearRecipeData_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipe = RecipeListBox.SelectedItem.ToString();
                recipeApp.ClearRecipeData(selectedRecipe);
                MessageBox.Show("The recipe data has been cleared.");
                RecipeListBox.Items.Remove(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Please select a recipe to clear data.");
            }
        }

        private void FilterRecipes_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = IngredientFilterTextBox.Text;
            string foodGroup = FoodGroupFilterTextBox.Text;
            if (double.TryParse(CalorieFilterTextBox.Text, out double maxCalories))
            {
                var filteredRecipes = recipeApp.FilterRecipes(ingredient, foodGroup, maxCalories);
                RecipeListBox.Items.Clear();
                foreach (var recipe in filteredRecipes)
                {
                    RecipeListBox.Items.Add(recipe.Name);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.");
            }
        }
    }
}