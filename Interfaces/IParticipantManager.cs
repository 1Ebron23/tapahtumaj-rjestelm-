using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tapahtumaJärjestelmä.Models;

namespace tapahtumaJärjestelmä.Interfaces
{
    public interface IParticipantManager
    {
        void AddParticipant(Participant participant);       // Add a participant
        void RemoveParticipant(Participant participantName);      // Remove a participant by name
        int GetNextID();             // Retrieve a participant by ID
        List<Participant> GetAllParticipants();
    }
}
