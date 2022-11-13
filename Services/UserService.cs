using OVAPI.Business;
using OVAPI.Models;
using System;

namespace OVAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataContext"></param>
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> Get()
        {
            List<User> users = new List<User>();
            List<UserModel> userModels = _dataContext.Users.ToList();

            foreach(UserModel model in userModels)
            {
                users.Add(new User
                {
                    Id = model.Id,
                    Username = model.Username,
                    Password = model.Password,
                    Currency = model.Currency,
                    Admin = model.Admin,
                    Active = model.Active
                });
            }

            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? Get(int id)
        {
            UserModel? model = _dataContext.Users.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                return new User
                {
                    Id = model.Id,
                    Username = model.Username,
                    Password = model.Password,
                    Currency = model.Currency,
                    Admin = model.Admin,
                    Active = model.Active
                };
            }
            else return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Add(User user)
        {
            UserModel userModel = new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Currency = user.Currency,
                Admin = user.Admin,
                Active = user.Active
            };

            _dataContext.Users.Add(userModel);
            _dataContext.SaveChanges();

            user.Id = userModel.Id;
            return user;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public bool Update(User user)
        {
            UserModel? userModel = _dataContext.Users.FirstOrDefault(x => x.Id == user.Id);

            if (userModel != null)
            {
                userModel.Id = user.Id;
                userModel.Username = user.Username;
                userModel.Password = user.Password;
                userModel.Currency = user.Currency;
                userModel.Admin = user.Admin;
                userModel.Active = user.Active;
                _dataContext.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            UserModel? userModel = _dataContext.Users.FirstOrDefault(x => x.Id == id);

            if (userModel != null)
            {
                _dataContext.Users.Remove(userModel);
                _dataContext.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
