using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient();
            string uri = "majors-indexes/" + GetUriSuffix(indexType);
            MajorIndex majorIndex = await client.GetAsync<MajorIndex>(uri);
            majorIndex.Type = indexType;
            return majorIndex;
        }

        private static string GetUriSuffix(MajorIndexType indexType)
        {
            return indexType switch
            {
                MajorIndexType.DowJones => ".DJI",
                MajorIndexType.Nasdaq => ".IXIC",
                MajorIndexType.SP500 => ".INX",
                _ => throw new Exception("MajorIndexType does not have a suffix defirnd"),
            };
        }
    }
}

