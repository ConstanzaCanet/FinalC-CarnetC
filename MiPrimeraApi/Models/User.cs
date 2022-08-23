using System;


namespace MiPrimeraApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public User()
        {
            Id = 0;
            Name = string.Empty;
            Lastname = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }

        public User(int id, string name, string lastname, string userName, string password, string email)
        {
            Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
        }

    }
}
