using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileManager.Web.WebAPI
{
    public class ProductController : ApiController
    {
        public IEnumerable<string> GetAssignableTeamNamesForProduct(int id, string input)
        {
            var repo = new TeamRepository();

            var assignableTeams = repo.GetAssignableTeamsForProduct(id);

            return assignableTeams.Where(x => x.Name.Contains(input)).Select(x => x.Name).ToList();
        }

        public IHttpActionResult GetAssignTeamToProduct(int id, string name)
        {
            var productRepo = new ProductRepository();

            if (!productRepo.AssignTeamToProduct(id, name))
                return NotFound();

            return Ok();
        }

        [HttpPost]
        public HttpResponseMessage PostUnassignTeam([FromBody] string name)
        {
            var productRepo = new ProductRepository();

            if (!productRepo.UnAssignTeamFromProduct(name))
                return Request.CreateResponse(HttpStatusCode.BadRequest); 

            return Request.CreateResponse(HttpStatusCode.OK); 
        }

    }
}
