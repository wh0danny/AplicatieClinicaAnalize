﻿using System.ComponentModel.DataAnnotations;

namespace AplicatieClinicaAnalize.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Analiza Analiza { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
