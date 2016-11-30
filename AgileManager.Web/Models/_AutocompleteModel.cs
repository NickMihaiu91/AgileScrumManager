using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileManager.Web.Models
{
    public class _AutocompleteModel
    {
        public string UrlAutocomplete { get; set; }

        public string UrlAdd { get; set; }

        public string UrlDelete { get; set; }

        public ICollection<string> ExistingItems { get; set; }

        public int ProductId { get; set; }

        public string AssignPanelHeader { get; set; }

        public string AssigneesPanelHeader { get; set; }
    }
}