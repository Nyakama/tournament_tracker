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
