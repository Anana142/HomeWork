using System;
using System.Collections.Generic;

namespace HomeWork;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Good> Goods { get; } = new List<Good>();
}
