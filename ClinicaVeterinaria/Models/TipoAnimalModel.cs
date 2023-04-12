﻿
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class TipoAnimalModel
    {
        public int TipoAnimalId { get; set; }

        [Required]
        public string? CategoriaAnimal { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
    }
}