using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Contracts.Items;

public record ItemDto(
    int Id,
    string ItemName,
    string Description,
    decimal BaseUnitPrice);