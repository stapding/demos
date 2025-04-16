﻿using System;
using System.Collections.Generic;

namespace WpfDEMO.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
