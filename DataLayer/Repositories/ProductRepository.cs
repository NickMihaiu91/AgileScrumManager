using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private bool CheckForDuplicate(string productName)
        {
            return _context.Products.Any(x => x.Name == productName);
        }

        public bool AddProduct(Product product)
        {
            if (CheckForDuplicate(product.Name))
                return false;

            var backlog = new Backlog();

            _context.Backlogs.Add(backlog);
            _context.SaveChanges();

            product.Backlog = backlog;

            _context.Products.Add(product);
            _context.SaveChanges();

            return true;
        }

        public bool EditProduct(Product product)
        {
            if (CheckForDuplicate(product.Name))
                return false;

            var storedProduct = GetById(product.Id);
            storedProduct.Name = product.Name;

            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetById(id);

            if (product == null)
                return false;

            var teamsAssignedToProduct = _context.Teams.Where(x => x.ProductId == id).ToList();

            foreach (var team in teamsAssignedToProduct)
                team.ProductId = null;

            _context.SaveChanges();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }

        public bool AssignTeamToProduct(int productId, string teamName)
        {
            if (GetById(productId) == null)
                return false;

            var team = _context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

            if (team == null)
                return false;

            team.ProductId = productId;
            _context.SaveChanges();

            return true;
        }

        public bool UnAssignTeamFromProduct(string teamName)
        {
            var team = _context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

            if (team == null)
                return false;

            team.ProductId = null;

            _context.SaveChanges();

            return true;
        }

        public Product GetProductForProductOwner(int userId)
        {
            return _context.Products.Where(x => x.ProductOwners.Any(y => y.Id == userId)).FirstOrDefault();
        }

    }
}
