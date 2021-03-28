﻿using AnimalsFriends.Helpers;
using AnimalsFriends.Models;
using AnimalsFriends.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsFriends.Services
{
    public class AnimalService : IAnimalRepository
    {
        private readonly IAnimalRepository _animalRepository;

        private readonly AnimalsFriendsContext _context;

        public AnimalService(IAnimalRepository animalRepository, AnimalsFriendsContext context)
        {
            _animalRepository = animalRepository;
            _context = context;

            _context.Database.EnsureCreated();
        }

        public List<Animal> GetAll(AnimalQueryParameters queryParameters)
        {
            IQueryable<Animal> animals = _context.Animals;

            if (queryParameters.Status != null)
            {
                animals = animals.Where(a => a.CurrentStatus.ToString().ToLower() == queryParameters.Status.ToLower());
            }

            if (queryParameters.Species != null)
            {
                animals = animals.Where(a => a.Species.ToString().ToLower() == queryParameters.Species.ToLower());
            }

            animals = animals
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);
          
            return  animals.ToList();
        }

        public Animal GetAnimal(int id)
        {
            return _context.Animals.Find(id);
        }

        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();           
        }

        public void UpdateAnimal(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public Animal FindAnimal(int id)
        {
            return _context.Animals.Find(id);
        }
    }
}
