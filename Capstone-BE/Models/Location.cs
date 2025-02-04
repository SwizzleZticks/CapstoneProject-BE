using System;
using System.Collections.Generic;

namespace Capstone_BE.Models;

public partial class Location
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public int LocationId { get; set; }
=======
    public short LocationId { get; set; }  // Primary Key
>>>>>>> Stashed changes
=======
    public short LocationId { get; set; }  // Primary Key
>>>>>>> Stashed changes

    public string? City { get; set; }

    public string? State { get; set; }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public virtual ICollection<User> Users { get; set; } = new List<User>();
=======
    public virtual ICollection<User> Users { get; set; } = new List<User>();  // Relationships with Users
>>>>>>> Stashed changes
=======
    public virtual ICollection<User> Users { get; set; } = new List<User>();  // Relationships with Users
>>>>>>> Stashed changes
}

