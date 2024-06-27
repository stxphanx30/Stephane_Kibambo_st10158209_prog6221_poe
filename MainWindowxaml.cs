using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        private RecipeApp recipeApp;

        public MainWindow()
        {
            InitializeComponent();
            recipeApp = new RecipeApp();
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeApp);
            addRecipeWindow.ShowDialog();
        }

        private void DisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            RecipesListBox.Items.Clear();
            foreach (var recipe in recipeApp.GetRecipes())
            {
                RecipesListBox.Items.Add(recipe.Name);
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem != null)
            {
                string selectedRecipe = RecipesListBox.SelectedItem.ToString();
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
            if (RecipesListBox.SelectedItem != null)
            {
                string selectedRecipe = RecipesListBox.SelectedItem.ToString();
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
            if (RecipesListBox.SelectedItem != null)
            {
                string selectedRecipe = RecipesListBox.SelectedItem.ToString();
                recipeApp.ClearRecipeData(selectedRecipe);
                MessageBox.Show("The recipe data has been cleared.");
                RecipesListBox.Items.Remove(selectedRecipe);
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
                RecipesListBox.Items.Clear();
                foreach (var recipe in filteredRecipes)
                {
                    RecipesListBox.Items.Add(recipe.Name);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.");
            }
        }
    }
}