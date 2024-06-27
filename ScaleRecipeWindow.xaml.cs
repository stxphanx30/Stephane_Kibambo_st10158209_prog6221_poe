using poe_;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



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
            if (double.TryParse(FactorTextBox.Text, out double factor))
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
        private void FactorTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black; // Or any other color for active text
            }
        }


        private void FactorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter Scaling Factor"; // Restore placeholder
                textBox.Foreground = Brushes.Gray; // Or the initial placeholder color
            }
        }
    }
}