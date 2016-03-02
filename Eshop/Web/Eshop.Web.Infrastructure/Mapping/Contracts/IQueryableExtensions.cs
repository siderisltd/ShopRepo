namespace Eshop.Web.Infrastructure.Mapping.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper.QueryableExtensions;

    public static class IQueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
