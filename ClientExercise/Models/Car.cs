namespace ClientExercise.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Brand { get; set; }

        public DateTime YearOfProduction { get; set; }
    }
}
