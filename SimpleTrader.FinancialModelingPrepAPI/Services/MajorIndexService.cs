﻿using Newtonsoft.Json;
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
            using HttpClient client = new HttpClient();
            string uri = "https://financialmodelingprep.com//api/v3/majors-indexes/" + GetUriSuffix(indexType);

            HttpResponseMessage response = await client.GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
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
                _ => ".DJI",
            };
        }
    }
}

