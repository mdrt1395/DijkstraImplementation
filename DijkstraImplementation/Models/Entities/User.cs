﻿namespace DijkstraImplementation.Models.Entities
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required int Phone {  get; set; }
        public required string Password { get; set; }
    }
}
