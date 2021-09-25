using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.helper
{
    public class Pagination<T> : List<T>
    {
        public Pagination(IEnumerable<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { set; get; }
        public int TotalPages { set; get; }
        public int PageSize { set; get; }
        public int TotalCount { set; get; }
    }

    public static Pagination<T> CreateAsync(IQueryable<T> source, int currentPage, int pageSize){
         var count = source.Count();
         var items = source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
         return new Pagination<T>(items,count,currentPage,pageSize);
    }

}