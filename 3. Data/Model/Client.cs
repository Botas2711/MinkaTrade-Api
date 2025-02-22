﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string dni { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public byte[]? profile_picture { get; set; }
        public bool hasPremiun { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Chat> ChatsAsSender { get; set; } = new List<Chat>();
        public List<Chat> ChatsAsReceiver { get; set; } = new List<Chat>();
    }
}
