namespace ReaRobot.Infrastructure
{
    /// <summary>
    /// Does a transformation to a given input to output.
    /// Allows chaining multiple transformations to mutate the object.
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    public interface ITransformation<T> where T:class
    {
        T Apply(T input);
    }
}
