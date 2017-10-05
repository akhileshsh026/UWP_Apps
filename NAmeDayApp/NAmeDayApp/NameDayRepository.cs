using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace NAmeDayApp
{
    class NameDayRepository
    {
        private static List<NameDayModel> allNameDayCache;
        public static async Task<List<NameDayModel>> GetAllNameDayAsync()
        {
            if (allNameDayCache != null)
                return allNameDayCache;

            var client = new HttpClient();
            var stream = await client.GetStreamAsync("http://www.response.hu/namedays_hu.json");

            var serializer = new DataContractJsonSerializer(typeof(List<NameDayModel>));
            allNameDayCache = (List<NameDayModel>)serializer.ReadObject(stream);
            return allNameDayCache;
        }
    }
}
