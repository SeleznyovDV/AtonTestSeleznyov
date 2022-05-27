using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
