using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClasificacionPeliculasModel;

public partial class Moviescategory
{
  public int Id { get; set; }

  public int MovieId { get; set; }

  public int CategoryId { get; set; }

  public string MovieName { get; set; } = null;
  public string CategoryName { get; set; } = null;

  public virtual Category Category { get; set; } = null!;

  public virtual Movie Movie { get; set; } = null!;
  
  [NotMapped]
  public List<SelectListItem> Movies { get; set; } = null;
  
  [NotMapped]
  public List<SelectListItem> Categories { get; set; } = null;
}
