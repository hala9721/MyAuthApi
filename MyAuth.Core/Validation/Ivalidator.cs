namespace MyAuth.Core.Validation
{
    public interface Ivalidator<in T>
    {
        IReadOnlyCollection<string> Validate(T request);
    }
}
