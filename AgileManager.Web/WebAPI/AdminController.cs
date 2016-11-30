using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class AdminController : ApiController
    {

        // GET api/admin
        public IEnumerable<DonutChartModel> Get()
        {
            var userRepo = new UserRepository();
            var productRepo = new ProductRepository();
            var teamRepo = new TeamRepository();

            var collection = new List<DonutChartModel>();
            collection.Add(new DonutChartModel
            {
                label = "Users",
                value = userRepo.GetAll().Count
            });

            collection.Add(new DonutChartModel
            {
                label = "Products",
                value = productRepo.GetAll().Count
            });

            collection.Add(new DonutChartModel
            {
                label = "Teams",
                value = teamRepo.GetAll().Count
            });

            return collection;
        }

    }

    public class DonutChartModel
    {
        public string label { get; set; }

        public int value { get; set; }
    }
}
