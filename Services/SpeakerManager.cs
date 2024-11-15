using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tapahtumaJärjestelmä.Interfaces;

namespace tapahtumaJärjestelmä.Services
{
    public class SpeakerManager : ISpeakerManager
    {
        private Queue<string> speakingOrder;
        public SpeakerManager()
        {

            speakingOrder = new Queue<string>();   // there is no need for using Osallistuja (name/email/phone number) rather name only so do i change to string 


        }

        public void AddSpeaker( string speakerName)
        {
            if (speakerName.Trim().ToLower() != null)
            {

                speakingOrder.Enqueue(speakerName);
                Console.WriteLine($"{speakerName} has been added to the speaking order.");
            }
            else
            {
                Console.WriteLine("Invalid speaker name. Please provide a valid name.");
            }


        }






        public string GetNextSpeaker()
        {
            // Attempt to dequeue the next speaker
            if (speakingOrder.TryDequeue(out string currentSpeaker))
            {
                Console.WriteLine($"{currentSpeaker} is now speaking...");
                Thread.Sleep(2000);
                Console.WriteLine();
                return currentSpeaker; // Return and remove the current speaker from the queue
            }

            
            return null; // No speakers left
        }

        public string ShowNextSpeaker()
        {
            // Peek at the next speaker without removing
            if (speakingOrder.TryPeek(out string nextSpeaker))
            {
                Console.WriteLine($"The next speaker is: {nextSpeaker}");
                return nextSpeaker; // Return the next speaker without removing
            }

            Console.WriteLine("There are no speakers in the queue.");
            return null; // No speakers left
        }
    




        public void PopulateSpeakers(string speaker)
        {


            AddSpeaker(speaker);


        }

    }
}
    

