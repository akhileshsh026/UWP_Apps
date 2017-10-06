using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.Serialization;

namespace NAmeDayApp
{ 
    
    public static class NameDayRepository
    {
        private static List<NameDayModel> allNameDayCache;
        public static async Task<List<NameDayModel>> GetAllNameDayAsync()
        {
            if (allNameDayCache != null)
                return allNameDayCache;

            var client = new HttpClient();
            var stream =  await client.GetAsync(new Uri("http://www.response.hu/namedays_hu.json"));

            MemoryStream ms = new MemoryStream();

            var serializer = new DataContractJsonSerializer(typeof(List<NameDayModel>));

            serializer.WriteObject(ms, stream);
            ms.Position = 0;

            allNameDayCache = (List<NameDayModel>)serializer.ReadObject(ms);
            return allNameDayCache;

        }



    }
}

