using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using modelos.models;

namespace modelos.models;

public partial class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [DisplayName("Nombre")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
