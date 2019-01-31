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
        //1.full page
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

        //2.Ajax
        //public PartialViewResult GetPeopleData(string selectedRole = "All") {
        //    IEnumerable<Person> data = personData;
        //    if (selectedRole != "All") {
        //        Role selected = (Role)Enum.Parse(typeof(Role),selectedRole);
        //        data = personData.Where(p=>p.Role==selected);
        //    }
        //    return PartialView(data);
        //}

        public ActionResult GetPeople(string selectedRole = "All"){
            return View((object)selectedRole);
        }

        //3.JSON
        private IEnumerable<Person> GetData(string selectedRole) {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All") {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }
        
        //this is GET 
        public JsonResult GetPeopleDataJson(string selectedRole = "All") {
            //IEnumerable<Person> data = GetData(selectedRole); // uncorrect json view 
              var data=GetData(selectedRole)
                .Select(p=>new {
                        FirstName=p.FirstName,
                        LastName=p.LastName,
                        Role=Enum.GetName(typeof(Role),p.Role)
                });
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All") {
            return PartialView(GetData(selectedRole));
        }

    }
}