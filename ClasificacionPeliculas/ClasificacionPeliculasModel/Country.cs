using System;
using System.Collections.Generic;

namespace ClasificacionPeliculasModel;

public partial class Country
{
    public long Geonameid { get; set; }

    public string Alpha2Code { get; set; } = null!;

    public string Alpha3Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Capital { get; set; } = null!;

    public string Region { get; set; } = null;

    public string Subregion { get; set; } = null;

    public long? Population { get; set; } = null;

    public string Demonym { get; set; } = null;

    public string NumericCode { get; set; } = null;

    public string FlagUrl { get; set; } = null;

    public string Neighbours { get; set; } = null;

    public string Userlastmodified { get; set; } = null!;

    public DateTime Timecreated { get; set; }

    public DateTime? Timemodified { get; set; } = null;

    public virtual ICollection<Region> Regions { get; } = new List<Region>();
}
