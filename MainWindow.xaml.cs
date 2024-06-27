using poe_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace poe_
{
    /// <summary>
    ///// // Main window class for the Recipe Manager application.
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 

    public partial class MainWindow : Window
    {
        /// <summary>
        ///// // List to store recipes.
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 


        private List<Recipe> recipes = new List<Recipe>();

        /// <summary>
        ///// // Constructor to initialize the main window.
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 

        public MainWindow()
        {
            InitializeComponent();
        }

        // Method to handle "Add Recipe" button click.
        private void OnAddRecipeClick(object sender, RoutedEventArgs e)
        {
            ShowAddRecipeSection();
        }

        // Method to handle "View Recipes" button click.
        private void OnViewRecipesClick(object sender, RoutedEventArgs e)
        {
            DisplayAllRecipes();
        }

        // Method to handle "Scale Recipe" button click.
        private void OnScaleRecipeClick(object sender, RoutedEventArgs e)
        {
            ShowScaleRecipeSection();
        }

        // Method to handle "Clear Recipes" button click.
        private void OnClearRecipesClick(object sender, RoutedEventArgs e)
        {
            ClearAllRecipes();
        }

        // Method to handle "Filter Recipes" button click.
        private void OnFilterRecipesClick(object sender, RoutedEventArgs e)
        {
            FilterRecipes();
        }

        // Method to handle "Exit" button click.
        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            ExitApplication();
        }

        // Show the Add Recipe section.
        private void ShowAddRecipeSection()
        {
            ClearAddRecipeFields();
            AddRecipePanel.Visibility = Visibility.Visible;
            RecipeListBox.Visibility = Visibility.Collapsed;
            ScaleRecipePanel.Visibility = Visibility.Collapsed;
            FilterPanel.Visibility = Visibility.Collapsed;
        }

        // Display all recipes in the list.
        private void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.", "No Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            RecipeListBox.ItemsSource = recipes;
            RecipeListBox.Visibility = Visibility.Visible;
            AddRecipePanel.Visibility = Visibility.Collapsed;
            ScaleRecipePanel.Visibility = Visibility.Collapsed;
            FilterPanel.Visibility = Visibility.Collapsed;
        }

        // Show the Scale Recipe section.
        private void ShowScaleRecipeSection()
        {
            ScaleRecipePanel.Visibility = Visibility.Visible;
            AddRecipePanel.Visibility = Visibility.Collapsed;
            RecipeListBox.Visibility = Visibility.Collapsed;
            FilterPanel.Visibility = Visibility.Collapsed;
        }

        // Clear all recipes from the list.
        private void ClearAllRecipes()
        {
            recipes.Clear();
            MessageBox.Show("All recipes have been cleared.", "Recipes Cleared", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Filter recipes by the specified ingredient.
        private void FilterRecipes()
        {
            string ingredient = FilterIngredientTextBox.Text.Trim().ToLower();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))).ToList();

            if (filteredRecipes.Count == 0)
            {
                MessageBox.Show($"No recipes found with the ingredient '{ingredient}'.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                RecipeListBox.ItemsSource = filteredRecipes;
                RecipeListBox.Visibility = Visibility.Visible;
            }
        }

        // Exit the application.
        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        // Save the new recipe entered by the user.
        private void OnSaveRecipeClick(object sender, RoutedEventArgs e)
        {
            var newRecipe = new Recipe
            {
                RecipeName = RecipeNameTextBox.Text,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = IngredientNameTextBox.Text,
                        Quantity = double.Parse(IngredientQuantityTextBox.Text),
                        Unit = IngredientUnitTextBox.Text,
                        Calories = double.Parse(IngredientCaloriesTextBox.Text)
                    }
                },
                Steps = RecipeStepsTextBox.Text
            };

            recipes.Add(newRecipe);
            MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            ClearAddRecipeFields();
        }

        // Clear the fields in the Add Recipe section.
        private void ClearAddRecipeFields()
        {
            RecipeNameTextBox.Clear();
            IngredientNameTextBox.Clear();
            IngredientQuantityTextBox.Clear();
            IngredientUnitTextBox.Clear();
            IngredientCaloriesTextBox.Clear();
            RecipeStepsTextBox.Clear();
        }

        // Handle the text box focus event to clear placeholder text.
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Enter Recipe Name" || textBox.Text == "Enter Ingredient" ||
                textBox.Text == "Enter Quantity" || textBox.Text == "Enter Unit" ||
                textBox.Text == "Enter Calories" || textBox.Text == "Enter Steps" ||
                textBox.Text == "Enter Ingredient Name")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        // Handle the text box lost focus event to set placeholder text if empty.
        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "RecipeNameTextBox":
                        textBox.Text = "Enter Recipe Name";
                        break;
                    case "IngredientNameTextBox":
                        textBox.Text = "Enter Ingredient";
                        break;
                    case "IngredientQuantityTextBox":
                        textBox.Text = "Enter Quantity";
                        break;
                    case "IngredientUnitTextBox":
                        textBox.Text = "Enter Unit";
                        break;
                    case "IngredientCaloriesTextBox":
                        textBox.Text = "Enter Calories";
                        break;
                    case "RecipeStepsTextBox":
                        textBox.Text = "Enter Steps";
                        break;
                    case "FilterIngredientTextBox":
                        textBox.Text = "Enter Ingredient Name";
                        break;
                }
                textBox.Foreground = Brushes.Gray;
            }
        }

        // Apply the scale factor to the selected recipe.
        private void OnApplyScaleClick(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a recipe to scale.", "No Recipe Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedRecipe = RecipeListBox.SelectedItem as Recipe;
            double scaleFactor = 1.0;

            if (Scale0_5.IsChecked == true)
                scaleFactor = 0.5;
            else if (Scale2_0.IsChecked == true)
                scaleFactor = 2.0;
            else if (Scale3_0.IsChecked == true)
                scaleFactor = 3.0;

            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }

            MessageBox.Show("Recipe scaled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /////  // Handle recipe selection change to display details.
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 

        private void OnRecipeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var selectedRecipe = RecipeListBox.SelectedItem as Recipe;
                MessageBox.Show($"Recipe: {selectedRecipe.RecipeName}\nIngredients: {string.Join(", ", selectedRecipe.Ingredients.Select(i => $"{i.Quantity} {i.Unit} {i.Name}"))}\nSteps: {selectedRecipe.Steps}", "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}