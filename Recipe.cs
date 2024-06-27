using poe_;
using System.Collections.Generic;

namespace poe_
{
    /// <summary>
    ///// Class to represent a Recipe.
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    

    public class Recipe
    {
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Steps { get; set; }
    }
}

