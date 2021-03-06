﻿using Coffee.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Coffee.Models
{
    public class Drink : Product
    {
        public DrinkSizeEnum Size { get; set; }

        public List<Extra> Extras { get; set; }
    }
}
