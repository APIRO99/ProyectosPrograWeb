using System;
using System.Collections.Generic;

namespace admin.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; }

    public string ServiceDescription { get; set; }

    public decimal ServicePrice { get; set; }

    public virtual ICollection<Testimonial> Testimonials { get; } = new List<Testimonial>();
}
