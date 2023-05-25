using System;
using System.Collections.Generic;
using HomeWork;

namespace HomeWork;

public partial class Good
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int IdCategory { get; set; }

    public int IdManufacturer { get; set; }

    public decimal? Price { get; set; }

    public int? Discount { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;
}
