﻿using PrimeiroAppAws.Domain.Entities.Base;

namespace PrimeiroAppAws.Domain.Entities
{
    public class Post : BaseModel
    {
        public Post(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}