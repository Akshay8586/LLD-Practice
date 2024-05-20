using System;

namespace ExpenseManagerApp.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }

        public User(string id, string name, string email, int mobile)
        {
            Id = id;
            Name = name;
            Email = email;
            Mobile = mobile;
        }

        public override string ToString()
        {
            return $"User {{ Id = {Id}, Name = {Name}, Email = {Email}, Mobile = {Mobile} }}";
        }
    }
}


