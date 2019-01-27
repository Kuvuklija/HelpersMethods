using HelpersMethods.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace HelpersMethods.Controllers
{
    public class PeopleController : Controller
    {

        public ActionResult Index(){
            return View();
        }

        private Person[] personData = {
            new Person { FirstName="Adam", LastName="Freeman", Role=Role.Admin},
            new Person { FirstName="Vadim", LastName="Kisarov",Role=Role.Admin},
            new Person { FirstName="John", LastName="Smith", Role=Role.Guest},
            new Person { FirstName="Anne", LastName="Jones", Role=Role.User}
        };

        //public ActionResult GetPeople(){
        //    return View(personData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole) {
        //    if (selectedRole == null || selectedRole == "All")
        //        return View(personData);
        //    else{
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        return View(personData.Where(p => p.Role == selected));
        //    }
        //}

        //Ajax
        public PartialViewResult GetPeopleData(string selectedRole = "All") {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All") {
                Role selected = (Role)Enum.Parse(typeof(Role),selectedRole);
                data = personData.Where(p=>p.Role==selected);
            }
            return PartialView(data);
        }

        public ActionResult GetPeople(string selectedRole = "All") {
            return View((object)selectedRole);
        }
    }
}