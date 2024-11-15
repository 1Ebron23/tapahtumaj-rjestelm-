using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tapahtumaJärjestelmä.Interfaces;
using tapahtumaJärjestelmä.Models;

namespace tapahtumaJärjestelmä.Services
{
    public class ParticipantManager:IParticipantManager
    {
        private List<Participant> participants;
        private int nextID = 1; // Auto-increment ID
        private const int maxCapacity = 50;

        public ParticipantManager()
        {
            participants = new List<Participant>();
            PopulateParticipants();
        }

        // Add a participant
        public void AddParticipant(Participant participant)
        {
            if (participants.Count < maxCapacity)
            {
                participants.Add(participant);
                
                
            }
            else
            {
                Console.WriteLine("Event is full. Unable to register.");
            }
        }

        // Remove a participant by name

        public int GetNextID()
        {
            return nextID++;
        }
        public void RemoveParticipant(Participant participant)
        {
           
            if (participant != null)
            {
                participants.Remove(participant);
                Console.WriteLine($"{participant.Name} has been removed from the event.");
            }
            else
            {
                Console.WriteLine($"Participant with the name {participant.Name} was not found.");
            }
        }


        // Retrieve all participants
        public List<Participant> GetAllParticipants()
        {
            return new List<Participant>(participants); // Return a copy for safety
        }

        // Populate participants with initial data
        private void PopulateParticipants()
        {
            participants.Add(new Participant(nextID++, "John Doe", "john.doe@example.com", "123-456-7890"));
            participants.Add(new Participant(nextID++, "Jane Smith", "jane.smith@example.com", "234-567-8901"));
            participants.Add(new Participant(nextID++, "Emily Clark", "emily.clark@example.com", "345-678-9012"));
            participants.Add(new Participant(nextID++, "Michael Johnson", "michael.johnson@example.com", "456-789-0123"));
            participants.Add(new Participant(nextID++, "Sarah Lee", "sarah.lee@example.com", "567-890-1234"));
            participants.Add(new Participant(nextID++, "David Brown", "david.brown@example.com", "678-901-2345"));
            participants.Add(new Participant(nextID++, "Olivia Taylor", "olivia.taylor@example.com", "789-012-3456"));
            participants.Add(new Participant(nextID++, "James White", "james.white@example.com", "890-123-4567"));
            participants.Add(new Participant(nextID++, "Sophia Davis", "sophia.davis@example.com", "901-234-5678"));
            participants.Add(new Participant(nextID++, "Daniel Martinez", "daniel.martinez@example.com", "012-345-6789"));
        }
    }
}
