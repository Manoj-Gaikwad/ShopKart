using First_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First_Project.IRepository
{
    public interface IPersonsDataRepositiory
    {
        Task<List<PersonsData>> getAllPersons();
        Task<PersonsData> getPersonsById(int id);
        Task<PersonsData> addPersons(PersonsData personsData);
        Task<PersonsData> updatePerson(PersonsData personsData);
        Task<PersonsData> deletPerson(int id);
    }
}
