using System;
using System.Collections.Generic;

namespace modelos.models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public int Duration { get; set; }

    public string Director { get; set; } = null!;

    public string Actors { get; set; } = null!;

    public string Plot { get; set; } = null!;

    public decimal Rating { get; set; }

    public int Votes { get; set; }

    public string PosterUrl { get; set; } = null!;

    public string ImdbId { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; } = new List<Category>();
}
