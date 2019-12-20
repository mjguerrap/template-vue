using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MPS.MPSPadraoArquitetura.SharedKernel.DataTables.Base;

namespace MPS.MPSPadraoArquitetura.SharedKernel.Util
{
    public static class QueryHelper
{
	public static bool PropertyExists<T>(string propertyName)
	{
		return typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase |
												   BindingFlags.Public | BindingFlags.Instance) != null;
	}

	public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName)
	{
		if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
		{
			return Enumerable.Empty<T>().AsQueryable();
		}
		MethodInfo OrderByMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderBy" && method.GetParameters().Length == 2);
		ParameterExpression paramterExpression = Expression.Parameter(typeof(T));
		Expression orderByProperty = Expression.Property(paramterExpression, propertyName);
		LambdaExpression lambda = Expression.Lambda(orderByProperty, paramterExpression);
		MethodInfo genericMethod = OrderByMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
		object ret = genericMethod.Invoke(null, new object[] { source, lambda });
		return (IQueryable<T>)ret;
	}

	public static IQueryable<T> OrderByPropertyDescending<T>(this IQueryable<T> source, string propertyName)
	{
		if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase |
												BindingFlags.Public | BindingFlags.Instance) == null)
		{
			return Enumerable.Empty<T>().AsQueryable();
		}
		MethodInfo OrderByDescendingMethod =
		typeof(Queryable).GetMethods().Single(method => method.Name == "OrderByDescending" && method.GetParameters().Length == 2);

		ParameterExpression paramterExpression = Expression.Parameter(typeof(T));
		Expression orderByProperty = Expression.Property(paramterExpression, propertyName);
		LambdaExpression lambda = Expression.Lambda(orderByProperty, paramterExpression);
		MethodInfo genericMethod = OrderByDescendingMethod.MakeGenericMethod(typeof(T), orderByProperty.Type);
		object ret = genericMethod.Invoke(null, new object[] { source, lambda });
		return (IQueryable<T>)ret;
	}

	public static IQueryable<T> OrderByCustomProperty<T, U>(this IQueryable<T> query, Expression<Func<T, U>> expression, string order)
	{
		return order == DirecaoOrdenacaoDataTableEnum.Asc.ToString()
					? query.OrderBy(expression)
					: query.OrderByDescending(expression);
	}
}
}
