﻿using System.ComponentModel.DataAnnotations;

namespace CLOUD;

public class MedicRequest
{
    [Required]
    public string TipMedic { get; set; }
}