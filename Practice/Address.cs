using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public int CountryId { get; set; }
        private string _path = @"C:\Users\nexen\source\repos\Practice\Repository\address.json";


        public Address()
        {

        }
        public Address(int iD, string street, string city, int postCode, int countryId)
        {
            ID = iD;
            Street = street;
            City = city;
            PostCode = postCode;
            CountryId = countryId;
        }

        public int SaveAddress(string street, string city, int postalCode, int countryId)
        {
            var list = new List<Address>();

            //napraviti genericku metodu!!!
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                list = JsonConvert.DeserializeObject<List<Address>>(json);
            }
            try
            {
                int id = list.Count > 0 ? list.LastOrDefault().ID + 1 : 1;
                Address address = new Address(id, street, city, postalCode, countryId);
                list.Add(address);

                var serializedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(_path, serializedJson);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IList<Address> FilterAddress(string _address)
        {
            var list = _getAllAddresses().Where(x => x.Street.ToLower().Contains(_address)).ToList();
            return list;
        }

        private List<Address> _getAllAddresses()
        {
            var list = new List<Address>();
            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                list = (List<Address>)serializer.Deserialize(file, typeof(List<Address>));
            }

            return new List<Address>();
        }
    }
}
