using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tapahtumaJärjestelmä.Interfaces
{
    public interface ISpeakerManager
    {
        void AddSpeaker(string speaker);                    
        string GetNextSpeaker();

        string ShowNextSpeaker();
        void PopulateSpeakers(string speaker);



    }
}
