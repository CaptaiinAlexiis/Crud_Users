using Crud.Models.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Drawing;

namespace Crud.Models.DB
{
    public class MyDatabase : DbContext
    {
       // protected readonly IConfiguration mConfiguration;
        public  DbSet<User> Users { get; set; }

        public MyDatabase(/*IConfiguration _configuration*/)
        {
            //mConfiguration = _configuration;
            Users = Set<User>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //need to find another way for this maybe
            string connectionString = "Server=127.0.0.1;Database=Crud_Alexis;User=root;Password=";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public void Add(User _user)
        {
            Users.Add(_user);
            SaveChanges();
        }

        public void Update(User _user)
        {
            Users.Update(_user);
            SaveChanges();
        }

        public void Delete(User _user)
        {
            Users.Remove(_user);
            SaveChanges();
        }

        public List<User> List(){ return Users.ToList(); }

        public User Get(int _id) { return Users.FirstOrDefault(_user => _user.ID == _id); }
    }
}
