using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    // TODO - Wire up the CreatePrize for the text files. 
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            // Find the max ID
            int currentId = 1;

            if(people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // Add the new record with the new ID (max + 1)
            model.Id = currentId;

            // Save the list<string> to the text file
            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {

            // Takes the prize file, finds the full file path, loads the file, converts it to a PrizeModels list
            // and returns it to the variable (Load the text file and converts the text to List<PrizeModel>)
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;           
           
        }
    }
}
