using poe_;
using System.Windows;

namespace poe_
{
    public partial class ScaleRecipeWindow : Window
    {
        private RecipeApp recipeApp;
        private Recipe selectedRecipe;

        public ScaleRecipeWindow(RecipeApp app, Recipe recipe)
        {
            InitializeComponent();
            recipeApp = app;
            selectedRecipe = recipe;
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ScaleFactorTextBox.Text, out double factor))
            {
                selectedRecipe.ScaleRecipe(factor);
                MessageBox.Show("Recipe scaled successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid scale factor.");
            }
        }
    }
}