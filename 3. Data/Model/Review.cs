﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int SendById { get; set; }
        public Client SendBy { get; set; }
    }
}
