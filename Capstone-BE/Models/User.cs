using System;
using System.Collections.Generic;

namespace Capstone_BE.Models;

public partial class User
{
    public short Id { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }
}
