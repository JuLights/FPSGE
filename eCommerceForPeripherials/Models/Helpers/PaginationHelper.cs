using System;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceForPeripherials.Models.Helpers
{
    public static class PaginationHelper
    {
        /// <summary>
        /// takes 3 argument, data count per Page, Page Id and ListData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageResults">count of item in list</param>
        /// <param name="Id">Page id</param>
        /// <param name="data"> list of data</param>
        /// <returns>returns specific count of List</returns>

        public static List<T> GetRangedData<T>(float pageResults, int Id, List<T> data)
        {

            var result = data
                .Skip((Id - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type Of Data</typeparam>
        /// <param name="data"> Parameter of that Type</param>
        /// <param name="pageResult"> page count</param>
        /// <returns>count of pages</returns>

        public static double GetPageCount<T>(List<T> data, float pageResult)
        {
            return Math.Ceiling(data.Count / pageResult);
        }


    }
}
