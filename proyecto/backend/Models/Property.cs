using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Property
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Status { get; set; } = null!;
}
