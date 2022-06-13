using Microsoft.AspNetCore.Mvc;
using MVC_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Data.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult displayPeople()
        {

      
            return PartialView("_displayPeople", PeopleViewModel.listOfPersons);
        }



        [HttpPost]
        public ActionResult displayPeopleSearch(string Name)
        {
            string name = Name;
            if (!String.IsNullOrEmpty(Name) || Name == null)
            {
                foreach (var prsn in PeopleViewModel.listOfPersons)
                {
                    int.TryParse(Name, out int result);
                    if (prsn.Name == name || prsn.Id == result)
                    {
                        //Add the found person to the list
                        List<Person> lst = new List<Person> {prsn };
                        return PartialView("_displayPeople", lst);

                    }
                }
            }
            //person not found -> index
            return PartialView("_displayPeople", null);

        }

        public ActionResult displayPeopleDelete(string Name)
        {
            string name = Name;
            if (!String.IsNullOrEmpty(Name) || Name == null)
            {
                foreach (var prsn in PeopleViewModel.listOfPersons)
                {
                    int.TryParse(Name, out int result);
                    if (prsn.Name == name || prsn.Id == result)
                    {
                        //remove 
                        PeopleViewModel.listOfPersons.Remove(prsn);
                        return PartialView("_displayPeople", PeopleViewModel.listOfPersons);

                    }
                }
            }
            //person not found -> index
            return PartialView("_displayPeople", null);

        }










        public ActionResult ListOfPeople()
        {
            //Send List of persons to view
            ViewBag.LinkableId = PeopleViewModel.listOfPersons;
            
            //display list of people

            //The table data should come from a view model, which should have a list of people, and
            //the search phrase if one exists.

            return View(PeopleViewModel.listOfPersons);
        }


            public ActionResult CreateEdit(int? id)
        {
            Person model = new Person();
            model.Name = "Testar massor";
            if (id.HasValue)
            {
                //Write your get user details code here.  
            }
            return PartialView("_CreateEdit", model);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateEdit(Person model)
        {
            //validate user  
            if (!ModelState.IsValid)
                return PartialView("_CreateEdit", model);


            //save user into database   
            return RedirectToAction("index");
        }


    [HttpPost]
        public IActionResult ListOfPeople(string searchTerm, string personName, string personCity, int personPhoneNumber, int personId)
        {
      
            //Searchpart 
            if (searchTerm != null)
            {
                foreach (Person person in PeopleViewModel.listOfPersons)
                {

                    if (person.Name.Equals(searchTerm) || person.City.Equals(searchTerm))
                    {
                        PeopleViewModel.listOfPersonsFiltered.Add(person);
                    }
                }
                ViewBag.LinkableId = PeopleViewModel.listOfPersonsFiltered;
                return View();

            }
            //add person
            else if (personName != null && personCity != null && personPhoneNumber != 0 && personId != 0 )
            {
                Person createdPerson = new Person { Name = personName, City = personCity, PhoneNumber = personPhoneNumber, Id = personId };
                PeopleViewModel.listOfPersons.Add(createdPerson);
                ViewBag.LinkableId = PeopleViewModel.listOfPersons;
            }

            //Filter out persons

            return View();
        }



    }
}
