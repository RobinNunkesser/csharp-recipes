using System;
using FunctionalSharp.DiscriminatedUnions;

namespace PlaceholderPosts.Common
{
    public delegate TDestination MapDelegate<TSource, TDestination>(
        TSource source);

    /// <summary>
    /// Class associated with a result or an error.
    /// </summary>
    public class Result<T> : DiscriminatedUnion<T, Exception>
    {
        public Result(T value) : base(value)
        {
        }

        public Result(Exception error) : base(error)
        {
        }

        public Result<TDestination> Map<TDestination>(
            MapDelegate<T, TDestination> mapping)
        {
            switch (tag)
            {
                case 0: return new Result<TDestination>(mapping(Item1));
                case 1: return new Result<TDestination>(Item2);
                default: throw new InvalidOperationException();
            }
        }
    }
}