using MyAuth.Domain.Commands;

namespace MyAuth.Core.Validation
{
    internal sealed class LoginCommandValidator :Ivalidator<LoginCommand>
    {
        public IReadOnlyCollection<string> Validate(LoginCommand request)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(request.Username))errors.Add("Username is required.");
            if (string.IsNullOrWhiteSpace(request.Password))errors.Add("Password is required.");
            return errors;
        }
    }

    internal sealed class RegisterCommandValidator : Ivalidator<RegisterCommand>
    {
        public IReadOnlyCollection<string> Validate(RegisterCommand request)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(request.Username)) errors.Add("Username is required.");
            if (string.IsNullOrWhiteSpace(request.Password)) errors.Add("Password is required.");
            if (string.IsNullOrWhiteSpace(request.Email)|| !request.Email.Contains("@")) errors.Add("Email is required.");
            return errors;
        }
    }
}
