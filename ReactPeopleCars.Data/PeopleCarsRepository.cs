using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReactPeopleCars.Data
{
    public class PeopleCarsRepository
    {
        private readonly string _connectionString;

        public PeopleCarsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.People.Include(p => p.Cars).ToList();
        }

        public void AddPerson(Person person)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            context.People.Add(person);
            context.SaveChanges();
        }

        public Person GetById(int id)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.People.FirstOrDefault(p => p.Id == id);
        }

        public void AddCar(Car car)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public List<Car> GetCars(int personId)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.Cars.Where(c => c.PersonId == personId).ToList();
        }

        public void DeleteCarsForPerson(int personId)
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            var carsToDelete = context.Cars.Where(c => c.PersonId == personId);
            context.Cars.RemoveRange(carsToDelete);
            context.SaveChanges();
        }

        public int GetRandomPersonId()
        {
            using var context = new PeopleCarsDataContext(_connectionString);
            return context.People.ToList().OrderBy(_ => new Random().Next()).First().Id;
        }
    }
}