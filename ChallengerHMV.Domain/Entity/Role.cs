﻿namespace ChallengerHMV.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime UpdatedIn { get; set; }
    }
}
