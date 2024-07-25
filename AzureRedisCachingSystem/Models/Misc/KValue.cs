namespace AzureRedisCachingSystem.Models.Misc
{
    /// <summary>
    /// Represents a value with a generic type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class KValue<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KValue{T}"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value to initialize the instance with.</param>
        public KValue(T value)
        {
            Value = value;
        }

        // Other properties or methods can be added here if needed
    }
}
