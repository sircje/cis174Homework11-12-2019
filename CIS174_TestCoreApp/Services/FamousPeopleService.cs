using CIS174_TestCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer.Design;

namespace CIS174_TestCoreApp.Services
{
    public class FamousPeopleService
    {
        private readonly AppDbContext _context;
       
        
        
        public FamousPeopleService(AppDbContext context)
        {
            _context = context;
        }
        public bool DoesPersonExist(int id)
        {
            var person = _context.FamousPeoples.Find(id);

            if(person == null)
            {
                return false;
            }
            return true;

        }
        public FamousPeopleViewModel GetFamousPersonDetail(int id)
        {
            var person = _context.FamousPeoples
                .Where(x => x.FamousPeopleId == id)
                .Select(x => new FamousPeopleViewModel
                {
                    FamousPeopleId = x.FamousPeopleId,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    birthDate = x.birthDate,
                    city = x.city,
                    state = x.state


                }).SingleOrDefault();
            return person;
        }

        public void UpdateFamousPeople(int id, UpdateFamousPeopleCommand command)
        {
            var person = _context.FamousPeoples.Find(id);
            if(person == null)
            { throw new Exception("Person not found"); }

            person.FamousPeopleId = command.FamousPeopleId;
                    person.firstName = command.firstName;
                    person.lastName = command.lastName;
                    person.birthDate = command.birthDate;
                    person.city = command.city;
                    person.state = command.state;
            _context.SaveChanges();
        
        }




        //static readonly AppDbContext _context;
        public static int CreateFamousPeople(FamousPeople cmd)
        {
            
            var fp = new FamousPeople
            {
                firstName = cmd.firstName,
                FamousPeopleId = cmd.FamousPeopleId,
                lastName = cmd.lastName,
                birthDate = cmd.birthDate,
                city = cmd.city,
                state = cmd.state,
                Achievements = cmd.Achievements?.Select(i=> new Achievements { 
                    AchievementsId = i.AchievementsId,
                    FamousPeopleId = i.FamousPeopleId,
                    name = i.name,
                    doa = i.doa
                
                
                }).ToList()
            };
           // _context.Add(fp);
           // _context.SaveChanges();
            return fp.FamousPeopleId;


        }
    }
}
