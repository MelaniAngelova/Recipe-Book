using System;
using System.Collections.Generic;

namespace app.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Recipes = new HashSet<Recipes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
