using FiasClient.Models;
using FiasClient.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FiasClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult FulltextSearch()
        {
            Dictionary<int, AddrobjModel> addrobjs = new Dictionary<int, AddrobjModel>();
            addrobjs.Add(0, new AddrobjModel
            {
                FULLNAME = ""
            });
            return View(addrobjs.Values);
        }

        [HttpPost]
        public ActionResult PartialFulltextTable(FulltextSearchRepository fulltextSearch, ResponseRepository responseRepository, 
            string fulltextforminput)
        {
                string Id = Guid.NewGuid().ToString();
                fulltextSearch.FulltextSearchInfo(Id, fulltextforminput);
                return PartialView(responseRepository.GetFulltextInfo(Id));
        }

        public ActionResult AdvancedSearch(ResponseRepository responseRepository, AdvancedSearch advancedSearch)
        {
            string Id = Guid.NewGuid().ToString();
            advancedSearch.AdvSearchRoot(Id);
            return View(responseRepository.GetRoot(Id));
        }

        [HttpPost]
        public ActionResult PartialAdvancedTable(string subject, string district, string settlement, string locality, string planningelement, 
            string roadnetworkelement, string landnumber, string buildingnumber, string carseatnumber, string roomnumber, string radio, 
            AdvancedSearch advancedSearch, ResponseRepository responseRepository)
        {
            string Id = Guid.NewGuid().ToString();
            string addrobj = "";
            string house = "";
            string room = "";

            if (roomnumber != null)
            {
                room = roomnumber;
            }
            else
            {
                room = "null";
            }

            if (buildingnumber != null)
            {
                house = buildingnumber;
            }
            else
            {
                house = "null";
            }

            if (landnumber != null)
            {
                addrobj = landnumber;
            }
            else if (roadnetworkelement != null)
            {
                addrobj = roadnetworkelement;
            }
            else if (planningelement != null)
            {
                addrobj = planningelement;
            }
            else if (locality != null)
            {
                addrobj = locality;
            }
            else if (settlement != null)
            {
                addrobj = settlement;
            }
            else if (district != null)
            {
                addrobj = district;
            }
            else if (subject != null)
            {
                addrobj = subject;
            }

            advancedSearch.AdvSearchInfo(Id, radio, addrobj, house, room);

            return PartialView(responseRepository.GetInfo(Id));
        }
    }
}