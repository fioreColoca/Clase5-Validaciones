using System;
using System.ComponentModel.DataAnnotations;

namespace Clase5_Validaciones.Models
{
    internal class ValidationResultAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
        $"Ingrese solo numeros letras y/o simbolos de puntuacion.";

        protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
        {
            if (value != null)
            {
                var atributo = (string)value;
                string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";


                foreach (var item in specialChar)
                {
                    if (atributo.Contains(item))
                        return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    }
}