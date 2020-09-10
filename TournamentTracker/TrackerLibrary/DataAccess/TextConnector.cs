﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    // TODO - Wire up the CreatePrize for the text files. 
    public class TextConnector : IDataConnection
    {
        PrizeModel IDataConnection.CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}