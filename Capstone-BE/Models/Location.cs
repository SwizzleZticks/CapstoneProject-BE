using System;
using System.Collections.Generic;

namespace Capstone_BE.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
