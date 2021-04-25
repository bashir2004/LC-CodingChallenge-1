using LC_CodingChallenge.Repository.Interfaces;
using LC_CodingChallenge.Repository.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LC_CodingChallenge.Controllers
{
    public class LeaseController : Controller
    {
        readonly ILeaseRepository leaseRepository;
        public LeaseController(ILeaseRepository leaseRepository)
        {
            this.leaseRepository = leaseRepository;
        }
        public ActionResult Index()
        {
            List<Lease> leases = leaseRepository.GetAllleases();
            return View(leases);
        }
        
    }
}
