using FluentValidation.Results;

namespace PlantHere.Application.Exceptions
{
    [Serializable]
    public class CustomValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public CustomValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            var arr = errors.Select(x => $"Validation Failed: -- PropertyName : {x.PropertyName} -- ErrorMessage : {x.ErrorMessage}");

            return String.Join(" ,", arr);
        }

    }
}
