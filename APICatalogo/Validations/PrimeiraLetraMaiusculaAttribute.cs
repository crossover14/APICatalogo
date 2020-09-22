using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            
            var primeiraletra = value.ToString()[0].ToString();
            if (primeiraletra != primeiraletra.ToUpper())
            {
                return new ValidationResult("A Primeira Letra do produto deve ser maiuscula");
            }
            return ValidationResult.Success;
        }

       
    }
}
