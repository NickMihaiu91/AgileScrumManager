using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }

        public _AutocompleteModel AutocompleteModel { get; set; }
    }
}