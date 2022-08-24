using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.ResponseWrapper
{
    public class ServicePagingResponse<T> : ServiceResponse<IEnumerable<T>>
    {
        /// <summary>
        /// This is the max item per page
        /// </summary>
         /// <value></value>
        public int MaxItemsPerPage { get; set; }
        /// <summary>
        /// This is the total count of items that can be retrieved from the storage
        /// </summary>
        /// <value></value>
        public int MaxItems { get; set; }
        /// <summary>
        /// This is the total pages that can be created by the same query
        /// </summary>
        /// <value></value>
        public int MaxPages
        {
            get
            {
                if (MaxItems <= 0)
                {
                    return 1;
                }

                return ((MaxItems - 1) / MaxItemsPerPage) + 1;
            }
        }
        /// <summary>
        /// This specifies the request current page
        /// </summary>
        /// <value></value>
        public int CurrentPage { get; set; }
    }
}
