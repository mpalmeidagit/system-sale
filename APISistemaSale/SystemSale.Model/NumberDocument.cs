using System;
using System.Collections.Generic;

namespace SystemSale.Model;

public partial class NumberDocument
{
    public int IdNumberDocument { get; set; }

    public int LastNumber { get; set; }

    public DateTime? DateRegistration { get; set; }
}
