using SwaggerDemo.Interface;
using SwaggerDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SwaggerDemo.Services
{

    public class UserService : IUser
    {
        private List<User> users = new List<User>()
    {
        new User()
        {
            FirstName="dheeraj",
            Id=1,
            LastName="thodupunuri",
            Password="radian",
            Username="dheeraj_thodupunuri"
        },
         new User()
        {
            FirstName="drj",
            Id=2,
            LastName="thodupunuri",
            Password="Radian",
            Username="dheeraj_thodupunuri"
        }
    };
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => users.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password)));

            if (user == null)
            {
                return null;
            }
            user.Password = string.Empty;
            return user;
        }
    }
}
