using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tapahtumaJärjestelmä.Interfaces;

namespace tapahtumaJärjestelmä.Services
{
    public class AttendanceManager : IAttendanceManager
    {
        private HashSet<string> attendees = new HashSet<string>();

        // Adds an attendee to the list
        public void AddAttendance(string attendeeName)
        {
            if (!attendees.Contains(attendeeName))
            {
                attendees.Add(attendeeName);
                Console.WriteLine($"{attendeeName} has been added to attendance.");
            }
            else
            {
                Console.WriteLine($"{attendeeName} is already in attendance.");
            }
        }

        // Removes an attendee from the list by name
        public void RemoveAttendance(string attendeeName)
        {
            if (attendees.Remove(attendeeName))
            {
                Console.WriteLine($"{attendeeName} has been removed from attendance.");
            }
            else
            {
                Console.WriteLine($"{attendeeName} was not found in attendance.");
            }
        }

        // Retrieves a list of all attendees
        public HashSet<string> GetAllAttendees()
        {
            return new HashSet<string>(attendees);
        }
    }
}
