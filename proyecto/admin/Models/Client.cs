using System;
using System.Collections.Generic;

namespace admin.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string ClientName { get; set; }

    public string ClientEmail { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; } = new List<Testimonial>();
}
