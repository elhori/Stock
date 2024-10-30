using System.ComponentModel.DataAnnotations;

namespace Stock.Domain.Enums;

public enum UnitType
{
    [Display(Name = "كيلوغرام")]
    Kilogram,

    [Display(Name = "جرام")]
    Gram,

    [Display(Name = "لتر")]
    Liter,
}