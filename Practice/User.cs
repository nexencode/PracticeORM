using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Practice
{
    public class User
    {
        #region Fields and Properties
        private static int _userId { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int AddressId { get; set; }
        private IList<User> _allUsers { get; set; }
        private string _path = @"C:\Users\nexen\source\repos\Practice\Repository\users.json";
        #endregion

        #region Constructor
        public User()
        {
            _getAllUsers();
        }
        public User(int iD, string name, string email, int roleId, int addressId)
        {
            ID = iD;
            Name = name;
            Email = email;
            RoleId = roleId;
            AddressId = addressId;
        }
        #endregion

        #region Methods

        public int SaveUser(string name, string email, int roleId, int addressId)
        {
            var list = new List<User>();
            //save and return id from json file
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<User>>(json);
            }

            try
            {
                int id = list.Count > 0 ? list.LastOrDefault().ID + 1 : 1;

                User user = new User(id, name, email, roleId, addressId);

                list.Add(user);
                var serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);
                return id;
            }
            catch (Exception ex)
            {

                return 0;
            }
            
        }

        public User GetUser(int _userId)
        {
            // filter all users list
            var user = _getAllUsers().Where(x => x.ID == _userId).FirstOrDefault();
            return user;
        }
        private IList<User> _getAllUsers()
        {
            //think is there youu need private list _allUsers
            //get all users from json
            var list = new List<User>();
            return _allUsers != null ? _allUsers : list;
        }


        #endregion
    }
}
