using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tapahtumaJärjestelmä.Models
{
    public class Participant
    {

        public int ID { private get; set; } 
        public string Name {  get; set; } 
        public string Email {  get; set; }
        public string PhoneNumber { get; set; }

        public Participant(int id, string name, string email, string phoneNumber)
        {
            ID = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{ID} - {Name} - {Email} - {PhoneNumber}";
        }

    }
}
