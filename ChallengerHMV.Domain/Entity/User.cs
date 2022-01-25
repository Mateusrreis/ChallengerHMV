﻿namespace ChallengerHMV.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime UpdatedIn { get; set; }
    }
}