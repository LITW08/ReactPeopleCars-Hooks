using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReactPeopleCars.Data;
using ReactPeopleCars.Web.Models;

namespace ReactPeopleCars.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleCarsController : ControllerBase
    {
        private string _connectionString;

        public PeopleCarsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getall")]
        public List<Person> GetAll()
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetPeople();
        }

        [HttpPost]
        [Route("addperson")]
        public void AddPerson(Person person)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.AddPerson(person);
        }

        [HttpGet]
        [Route("GetPerson")]
        public Person GetPerson(int id)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetById(id);
        }

        [HttpPost]
        [Route("addcar")]
        public void AddCar(Car car)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.AddCar(car);
        }

        [HttpGet]
        [Route("getcars")]
        public List<Car> GetCars(int personId)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetCars(personId);
        }

        [HttpPost]
        [Route("deletecars")]
        public void DeleteCars(DeleteCarsViewModel vm)
        {
            var repo = new PeopleCarsRepository(_connectionString);
            repo.DeleteCarsForPerson(vm.PersonId);
        }

        [HttpGet]
        [Route("randompersonid")]
        public int RandomPersonId()
        {
            var repo = new PeopleCarsRepository(_connectionString);
            return repo.GetRandomPersonId();
        }
    }
}
