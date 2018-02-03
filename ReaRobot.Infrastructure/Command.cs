namespace ReaRobot.Infrastructure
{
    /// <summary>
    /// Base command to apply the transformation from one configuration to another
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ReaRobot.Infrastructure.ITransformation{T}" />
    public abstract class Command<T> : ITransformation<T> where T:class
    {
        /// <summary>
        /// Applies the specified input configuration.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The new configuration after transformation.</returns>
        public T Apply(T input)
        {
            if (input == null)
            {
                return null;
            }
            return ApplyInternal(input);
        }

        /// <summary>
        /// Applies the transformation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The new configuration after transformation.</returns>
        protected abstract T ApplyInternal(T input);
    }
}
