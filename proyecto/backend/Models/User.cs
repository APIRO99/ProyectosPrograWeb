using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public partial class User
{
    public int? Id { get; set; }

    public string? Name { get; set; } = null!;

    [Required]
    public string Username { get; set; } = null!;

    public string? Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
