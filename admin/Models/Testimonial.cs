using System;
using System.Collections.Generic;

namespace admin.Models;

public partial class Testimonial
{
    public int TestimonialId { get; set; }

    public string ClientName { get; set; }

    public string TestimonialText { get; set; }

    public int ServiceId { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; }

    public virtual Service Service { get; set; }
}
