using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedCode.Models
{
	public class WeatherResponse
	{
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("cod")]
        public string Cod { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("list")]
        public List<ListResponse> ListResponse { get; set; }
    }

    public class ListResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("wind")]
        public Wind wind { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("snow")]
        public Snow Snow { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public double SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public double GrndLevel { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Deg { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class Rain
    {
        [JsonPropertyName("h1")]
        public Double H1 { get; set; }

        [JsonPropertyName("h3")]
        public Double H3 { get; set; }
    }

    public class Snow
    {
        [JsonPropertyName("h1")]
        public Double H1 { get; set; }

        [JsonPropertyName("h3")]
        public Double H3 { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}

