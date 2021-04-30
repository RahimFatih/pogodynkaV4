using System;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.IO;
public class Weather
    {
        public int ID { get; set; }
        public string weatherDescription {get;set;}
        public float mainWeatherTemp {get;set;}
        public float visibility {get;set;}
        public string name { get; set; }
        public int uploadTime{get;set;}

        public int newEntry(string City)
        {   
            Console.WriteLine("----------------------------------)"+City);
            DownloadWeather myWeather = new DownloadWeather();
            myWeather = JsonConvert.DeserializeObject<DownloadWeather>(myWeather.getWeather(City));
            translateWeather(myWeather);
            return 0;
        }
        public int translateWeather(DownloadWeather myWeather)
        {
            weatherDescription = myWeather.weather[0].description;
            mainWeatherTemp = myWeather.main.temp;
            name = myWeather.name;
            uploadTime =int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            
            return 0; 
        }
    }
    public class Coord
    {
        public float lon;
        public float lat;
    }
    public class weather
    {
        public int id;
        public string main;
        public string description;
    }
    public class MainWeather
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public float pressure;
        public float humidity;
    }
    public class Wind
    {
        public float speed;
        public float deg;
    }
    public class Clouds
    {
        public float all;
    }
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public float sunrise;
        public float sunset;
    }

public class DownloadWeather
    {
        public Coord coord {get;set;}
        public weather[] weather {get;set;}
        //public string base {get; set; }
        public MainWeather main {get;set;}
        public float visibility {get;set;}
        public Wind wind{get;set;}
        public Clouds clouds{get;set;}
        public int dt{get;set;}
        public Sys sys{get;set;}
        public int timezone { get; set; }
        public int id {get;set;}
        public string name { get; set; }
        public int cod{get;set;}
        //public string main { get; set; }
        //public string feels_like { get; set; }
        //public DataSet weather { get; set; }
        
        public string getWeather(string City)
        {
            using(WebClient web = new WebClient())
            {
                string url =string.Format("https://api.openweathermap.org/data/2.5/weather?q="+City+"&appid=b0789adf874bd65919c23b49a964d714&units=metric");
                var json = web.DownloadString(url);
                //Console.WriteLine(json);
                return json;
            }
        }
        public int printWeather()
        {
            Console.WriteLine("Miasto: "+name);
            return 0;
        }
    }