using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;

namespace Dor.Challenge.Fernando.Test.Common
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AsAsyncQueryable<T>(this IEnumerable<T> input)
        {
            return new TestAsyncEnumerable<T>(input);
        }

    }

    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider Inner;

        public TestAsyncQueryProvider(IQueryProvider inner)
        {
            Inner = inner;
        }

        TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            Type expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var result =
                typeof(IQueryProvider)
                .GetMethod(
                    name: nameof(IQueryProvider.Execute),
                    genericParameterCount: 1,
                    types: new[] { typeof(Expression) })!
                .MakeGenericMethod(expectedResultType)
                .Invoke(this, new[] { expression });

            MethodInfo fromResultMethod = typeof(Task)
                .GetMethod(nameof(Task.FromResult))
                ?.MakeGenericMethod(expectedResultType)!;

            return (TResult)fromResultMethod.Invoke(null, new[] { result })!;
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return Inner.Execute(expression)!;
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            return Inner.Execute<TResult>(expression);
        }
    }

    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestAsyncQueryProvider<T>(this); }
        }
    }

    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> Inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            Inner = inner;
        }

        T IAsyncEnumerator<T>.Current => Inner.Current;

        ValueTask<bool> IAsyncEnumerator<T>.MoveNextAsync()
        {
            return new ValueTask<bool>(Inner.MoveNext());
        }

        ValueTask IAsyncDisposable.DisposeAsync()
        {
            Inner.Dispose();
            return default;
        }
    }
}
