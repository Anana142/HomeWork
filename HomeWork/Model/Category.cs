using System;
using System.Collections.Generic;
using HomeWork;

namespace HomeWork;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Good> Goods { get; } = new List<Good>();
}
