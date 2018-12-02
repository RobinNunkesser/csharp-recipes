using System;
namespace CleanArchRecipe.Common
{
    public class Response<T>
    {
        int tag;
        T value;
        Exception error;

        public Response(T value) { this.value = value; tag = 1; }
        public Response(Exception error) { this.error = error; tag = 2; }

        public virtual TResult Match<TResult>(
            Func<T, TResult> successHandler,
            Func<Exception, TResult> errorHandler
            )
        {
            if (successHandler == null) 
                throw new ArgumentNullException("successHandler");
            if (errorHandler == null) 
                throw new ArgumentNullException("errorHandler");

            switch (tag)
            {
                case 1: return successHandler(value);
                case 2: return errorHandler(error);
                default: throw new InvalidOperationException();
            }
        }

        public virtual void Match(
            Action<T> successHandler,
            Action<Exception> errorHandler
            )
        {
            if (successHandler == null) 
                throw new ArgumentNullException("successHandler");
            if (errorHandler == null) 
                throw new ArgumentNullException("errorHandler");

            switch (tag)
            {
                case 1: successHandler(value); break;
                case 2: errorHandler(error); break;
                default: throw new InvalidOperationException();
            }
        }

        public static bool operator ==(
            Response<T> instanceA,
            Response<T> instanceB
            )
        {
            if (ReferenceEquals(instanceA, null)) return ReferenceEquals(instanceB, null);

            return instanceA.Equals(instanceB);
        }

        public static bool operator !=(
            Response<T> instanceA,
            Response<T> instanceB)
        {
            return !(instanceA == instanceB);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var other = obj as Response<T>;

            if (other == null) return false;

            if (this.tag != other.tag) return false;

            return Case(this).Equals(Case(other));
        }

        private static object Case(Response<T> u)
        {
            switch (u.tag)
            {
                case 1: return u.value;
                case 2: return u.error;
                default: throw new InvalidOperationException();
            }
        }

        public override int GetHashCode()
        {
            return 17 * this.tag + Case(this).GetHashCode();
        }

        public string CaseToString()
        {
            switch (tag)
            {
                case 1: return value.ToString();
                case 2: return error.ToString();
                default: throw new InvalidOperationException();
            }
        }

        public Type CaseType()
        {
            switch (tag)
            {
                case 1: return value.GetType();
                case 2: return error.GetType();
                default: throw new InvalidOperationException();
            }
        }
    }
}
