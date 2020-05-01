namespace ApiExercise.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ApiExercise.CustomAttributes;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Brand { get; set; }

        [RangeDateTimeAttribute]
        public DateTime YearOfProduction { get; set; }
    }
}
