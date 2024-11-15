using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tapahtumaJärjestelmä.Interfaces
{
    public interface IAttendanceManager
    {
        void AddAttendance(string attendeeName);
        void RemoveAttendance(string attendeeName);
        HashSet<string> GetAllAttendees();
    }
}
