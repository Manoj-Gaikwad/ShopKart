using First_Project.Data;
using First_Project.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.Repository
{
    public class PersonsDataRepository : IPersonsDataRepositiory
    {
        private readonly DBConnection dBConnection;

        public PersonsDataRepository(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
        }

        public async Task<List<PersonsData>> getAllPersons()
        {
            return await dBConnection.persons.ToListAsync();
        }
        public async Task<PersonsData> getPersonsById(int id)
        {
            return await dBConnection.persons.SingleOrDefaultAsync(x => x.personID == id);
        }

        public async Task<PersonsData>addPersons(PersonsData personsData)
        {
            PersonsData persons = new PersonsData()
            {
                LastName = personsData.LastName,
                FirstName = personsData.FirstName,
                Address = personsData.Address,
                City = personsData.City,

            };
            await dBConnection.AddAsync(persons);
            await dBConnection.SaveChangesAsync ();
            return persons;
            
        }

        public async Task<PersonsData>updatePerson(PersonsData personsData)
        {
            PersonsData person = await dBConnection.persons.SingleOrDefaultAsync(x => x.personID == personsData.personID);

            if(person!=null)
            {
                person.LastName = personsData.LastName;
                person.FirstName = personsData.FirstName;
                person.Address = personsData.Address;
                person.City = personsData.City;
                await dBConnection.SaveChangesAsync();
            }
            return person;

        }
        public async Task<PersonsData>deletPerson(int id)
        {
            PersonsData persons = await dBConnection.persons.SingleOrDefaultAsync(x => x.personID == id);

            if(persons!=null)
            {
                dBConnection.Remove(persons);
                dBConnection.SaveChangesAsync();
            }
            return persons;
        }
        
    }
}
