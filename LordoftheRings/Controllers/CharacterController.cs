using System;
using System.Collections.Generic;
using System.Linq;
using LordoftheRings.Models;
using LordoftheRings.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
      
namespace LordoftheRings.Controllers
{
    //[Authorize]
    public class CharacterController : Controller
    {
        private ICharacterRepository characterRepository;
        private IRaceRepository raceRepository;

        public CharacterController(ICharacterRepository characterRepo, IRaceRepository raceRepo)
        {
            this.characterRepository = characterRepo;
            this.raceRepository = raceRepo;
        }


        // GET: /<controller>/
        //[AllowAnonymous]
        public IActionResult Index(string searchString)
        {
            List<Character> cList = this.characterRepository.Get();

            if (searchString != "" || searchString != null)
            {
                cList = this.characterRepository.Find(searchString);

            }

            ViewBag.keepSearch = searchString;

            return View("ShowCharacters", cList.ToList());
        }


        public string Hello()
        {
            return "Well, hello there! We are learning .NET Core now...";
        }

        public IActionResult MyFirstView()
        {
            ViewBag.MyWifeSays = "Go buy groceries, clean up, make dinner";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(ViewModelCreator.CreateCharacterVm(raceRepository));
        }

        [HttpPost]
        public IActionResult Create(CharactersVM vm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Thanks = vm.Character.Name;
                ViewBag.Character = vm.Character;

                characterRepository.Save(vm.Character);

                List<Character> chars = this.characterRepository.FindOppositeGender(vm.Character);

                return View("Thanks", chars.ToList());
            }

            return View(ViewModelCreator.CreateCharacterVm(raceRepository));

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Create an edit view
            // Look up cat object from catId in the database
            // Show an edit view to the user, displaying the cat object
            Character c = characterRepository.Get(id);


            return View("Edit", ViewModelCreator.EditCharacterVm(raceRepository, c));
        }

        [HttpPost]
        public IActionResult Edit(CharactersVM c)
        {
            if (ModelState.IsValid)
            {
                characterRepository.Save(c.Character);
                // Save it to the database
                return RedirectToAction("Index");
            }
            return View("Edit", ViewModelCreator.EditCharacterVm(raceRepository, c.Character));
        }
    }
}
