using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BingWallAvalonia.Models
{
    public class ImageModel
    {
        public int Number { get; set; }

        [JsonPropertyName("startdate")]
        public string Startdate { get; set; }

        [JsonPropertyName("fullstartdate")]
        public string Fullstartdate { get; set; }

        [JsonPropertyName("enddate")]
        public string Enddate { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("urlbase")]
        public string Urlbase { get; set; }


        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }


        [JsonPropertyName("copyrightlink")]
        public string Copyrightlink { get; set; }


        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("quiz")]
        public string Quiz { get; set; }

        [JsonPropertyName("wp")]
        public bool Wp { get; set; }

        [JsonPropertyName("hsh")]
        public string Hsh { get; set; }

        [JsonPropertyName("drk")]
        public int Drk { get; set; }
        public int Top { get; set; }
        public int Bot { get; set; }
        public object[] Hs { get; set; }
    }
}

 