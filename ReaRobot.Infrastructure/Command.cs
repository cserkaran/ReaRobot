namespace ReaRobot.Infrastructure
{
    public abstract class Command<T> : ITransformation<T> where T:class
    {
        public T Apply(T input)
        {
            if (input == null)
            {
                return null;
            }
            return ApplyInternal(input);
        }

        protected abstract T ApplyInternal(T input);
    }
}
