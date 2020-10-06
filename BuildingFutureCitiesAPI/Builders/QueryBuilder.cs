using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingFutureCitiesAPI.Builders
{
    public class QueryBuilder
    {
        //MATERIAL QUERIES
        public string GetDefaultQuery()
        {
            string qry = $@"SELECT * FROM `materials`";
            return qry;
        }
    }
}
