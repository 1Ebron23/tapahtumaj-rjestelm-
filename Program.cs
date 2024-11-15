using static tapahtumaJärjestelmä.Models.Participant;
using tapahtumaJärjestelmä.Interfaces;
using tapahtumaJärjestelmä.Services;
using tapahtumaJärjestelmä.Models;

namespace tapahtumaJärjestelmä
{
    public class Program
    {
        private static IParticipantManager _participant;
        private static ISpeakerManager _speaker;
        private static IAttendanceManager _attendance;



        static void Main(string[] args)
        {
            _participant = new ParticipantManager();
            _speaker = new SpeakerManager();
            _attendance = new AttendanceManager();
            


            while (true)
            {
                // Display the menu options
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. See list of participants");
                Console.WriteLine("2. See checked-in list");
                Console.WriteLine("3. Add a new participant");
                Console.WriteLine("4. Check in a participant");
                Console.WriteLine("5. Remove a participant");
                Console.WriteLine("6. Start speach");
                Console.WriteLine("7. Exit");

                // Read user input
                int choice;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!validChoice)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                    continue; // Go back to the menu
                }

                switch (choice)
                {
                    case 1:
                        // Show list of participants
                        Console.WriteLine("\nList of Participants:");
                        foreach (var particpant in _participant.GetAllParticipants())
                        {
                            Console.WriteLine(particpant.ToString());
                        }
                        break;

                    case 2:
                        // Show list of checked-in participants
                        ListCheckedInParticipants();
                        break;

                    case 3:
                        // Add a new participant
                        AddParticipants();
                        break;

                    case 4:
                        // Check in a participant
                        CheckInParticipant();
                        break;

                    case 5:
                        // Remove a participant
                        Console.WriteLine("Enter participant name to remove:");
                        string name = Console.ReadLine().Trim();
                        RemoveParticipant(name);
                        break;

                    case 6:
                        Console.WriteLine("Welcome to the event!");
                        PopulateSpeakers();
                        Console.WriteLine("__________________________");
                        EventStart();
                        break;

                    case 7:
                        // Exit the program
                        Exit();
                        return; // End the loop and exit the program



                    default:
                        Console.WriteLine("Please select a valid option (1-7).");
                        break;
                }
            }
        }
        public static void CheckInParticipant()
        {
            Console.WriteLine("Enter name to check in:");
            string name = Console.ReadLine().Trim();
            var osallistuja = _participant.GetAllParticipants().FirstOrDefault(x => x.Name.Trim().ToLower() == name.ToLower());
            if (osallistuja != null)
            {
                if (_attendance.GetAllAttendees().Contains(name.ToLower()))
                {
                    Console.WriteLine("You have already checked in.");
                }
                else
                {
                    _attendance.AddAttendance(name.ToLower()); // Add to checked-in list
                    
                }


            }
            else
            {
                Console.WriteLine("Participant not found in the registration list.");
            }





        }

        public static void ListCheckedInParticipants()
        {
            Console.WriteLine("Checked-in participants:");
            foreach (var name in _attendance.GetAllAttendees())
            {
                Console.WriteLine(name);
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Are you sure you want to exit? (y/n)");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "y")
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0); // Exits the program
            }
            else
            {
                Console.WriteLine("Returning to the menu...");
                // Add logic to return to the main menu or continue the program flow
            }
        }

        public static void AddParticipants()
        {
            Console.WriteLine("Enter participant name:");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("Enter participant email:");
            string email = Console.ReadLine().Trim();

            Console.WriteLine("Enter participant phone number:");
            string phonenumber = Console.ReadLine().Trim();

            Participant newParticipant = new Participant(_participant.GetNextID(),name, email, phonenumber);

            // Check if the participant is already registered by name (or could also be by email or phone)
            if (_participant.GetAllParticipants().Any(x => x.Name.Trim().ToLower() == name.ToLower()))
            {
                Console.WriteLine("Participant already registered.");
            }
            else
            {
               
                
                  
                    _participant.AddParticipant(newParticipant);
                    Console.WriteLine("Participant successfully added.");
                
            }
        }


        public static void RemoveParticipant(string participantName)
        {


            var participant = _participant.GetAllParticipants().FirstOrDefault(x => x.Name.Trim().ToLower() == participantName.Trim().ToLower());

            // Check if participant is found
            if (participant != null)
            {
                // Pass the found participant (of type Participant) to the remove method in the manager
                _participant.RemoveParticipant(participant);
                

                // Check if the participant is in the attendance list and remove them
                if (_attendance.GetAllAttendees().Contains(participantName))
                {
                    _attendance.RemoveAttendance(participantName); // Passing participantName as a string
                    
                }
            }
            else
            {
                Console.WriteLine($"Participant with the name {participantName} was not found.");
            }
        }

       


        public static void EventStart()
        {
            foreach (var currentSpeaker in _participant.GetAllParticipants())
            {

                _speaker.GetNextSpeaker();
                _speaker.ShowNextSpeaker();



            }
        }


        public static void PopulateSpeakers()

        {
            var listedparticipants = _participant.GetAllParticipants();
            foreach (var participant in listedparticipants)
            {
                _speaker.PopulateSpeakers(participant.Name);
            }



        }
    }
}
