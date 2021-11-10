using System.ComponentModel.DataAnnotations;

namespace JK.Common.Enumerations;

public enum DistanceUnit
{
    [Display(Name = "ft")]
    Feet,
    [Display(Name = "in")]
    Inches,
    [Display(Name = "m")]
    Meters,
    [Display(Name = "cm")]
    Centimeters
}
