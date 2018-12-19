using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LabTestPortal.Models;
using LabTestPortal.DataAccess;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Manage(int? personId)
        {
            ViewData["Title"] = "Add Person";
            var personModel = new PersonModel();
            if (personId != null)
            {
                var personDataModel = PersonData.GetPerson(personId.Value);
                personModel = AutoMap.Mapper.Map(personDataModel, personModel);
                ViewData["Title"] = "Edit " + personModel.FirstName + " " + personModel.LastName;
            }
            personModel.States = BuildStates();
            return PartialView("~/Views/Person/_Manage.cshtml", personModel);
        }

        public IActionResult PersonUpsert(PersonModel personModel, PersonSearchModel personSearchModel)
        {
            int? personId = PersonData.PersonUpsert(AutoMap.Mapper.Map(personModel, new PersonDataModel()));
            return RedirectToAction("Search", personSearchModel);
        }

        public IActionResult Search(PersonSearchModel personSearchModel)
        {
            ViewData["Title"] = "Search People";
            if (personSearchModel.PersonSearch != null) personSearchModel.Persons = AutoMap.Mapper.Map(PersonData.GetPersons(personSearchModel.PersonSearch), new List<PersonModel>());
            personSearchModel.States = BuildStates();
            return View(personSearchModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        private List<StateDataModel> BuildStates()
        {
            var stateDataModel = new List<StateDataModel>();
            stateDataModel.Add(new StateDataModel() { StateId = null, StateCode = "" });
            stateDataModel.AddRange(StateData.GetStates());
            return stateDataModel;
        }
    }
}
