﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    internal class EBook: Book
    {
        public override void DisplayInfo()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
}
