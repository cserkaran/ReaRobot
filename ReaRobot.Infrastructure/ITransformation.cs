namespace ReaRobot.Infrastructure
{
    /// <summary>
    /// Does a transformation to a given input to output.
    /// Allows chaining multiple transformations to mutate the object.
    /// </summary>
    /// <typeparam name="T">Type parameter</typeparam>
    public interface ITransformation<T> where T:class
    {
        /// <summary>
        /// Applies the specified input for transformation.
        /// </summary>
        /// <param name="input">The input to be transformed.</param>
        /// <returns>the transformed input as output</returns>
        T Apply(T input);
    }
}
