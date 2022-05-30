using System;

namespace Data.Validation
{
    public abstract class ValidSpecification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression();
            return predicate(entity);
        }

        public abstract Func<T, bool> ToExpression();
    }
}
