using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace JSONRecipe
{
    public class JSONService
    {
        public class Track
        {
            public string artistName { get; set; }
            public string collectionName { get; set; }
            public string trackName { get; set; }
            public int trackNumber { get; set; }
            public override string ToString()
            {
                return $"{trackNumber}  - {trackName} ";
            }
        }
        public JSONService()
        {
            var example = @"{""artistName"":""Jack Johnson"",
                             ""collectionName"":""In Between Dreams"",
                             ""trackName"":""Better Together"",
                             ""trackNumber"":1}";
            var jsonObject = JObject.Parse(example);
            var jsonString = jsonObject.ToString();
            var track = JsonConvert.DeserializeObject<Track>(jsonString);
            Debug.WriteLine(track);
        }
    }
}