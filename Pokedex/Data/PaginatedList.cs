using System;
using System.Collections.Generic;

namespace Pokedex.Data
{
    public class PaginatedList<T>
    {
        public int PageIndex  { get; private set; }
        public int PageSize   { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        
        public IEnumerable<T> Result { get; private set; }

        public PaginatedList(IEnumerable<T> content, int pageIndex, int pageSize, int totalCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int) Math.Ceiling(TotalCount / (double) PageSize);
            Result = content;
        }
    }
}