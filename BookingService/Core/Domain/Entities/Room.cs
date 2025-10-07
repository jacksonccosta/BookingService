using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level{ get; set; }
    public bool InMaintenance { get; set; }
    
    public bool WasGuest 
    {
        //TODO: Implement logic to check if the room was ever booked by a guest
        get { return true; } 
    }

    public bool IsAvailable {
        get { 
            if (InMaintenance || WasGuest) return false;
            return true;
        }
    }
}
