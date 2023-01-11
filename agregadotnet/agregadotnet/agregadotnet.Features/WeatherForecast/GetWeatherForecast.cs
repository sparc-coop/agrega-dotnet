﻿namespace agregadotnet.Features
{
    public class GetWeatherForecast : PublicFeature<List<WeatherForecast>>
    {
        public GetWeatherForecast(IRepository<WeatherForecast> weatherForecastRep)
        {
            WeatherForecastRep = weatherForecastRep;
        }

        public IRepository<WeatherForecast> WeatherForecastRep { get; set; }

        public override async Task<List<WeatherForecast>> ExecuteAsync()
        {
            return await Task.FromResult(WeatherForecastRep.Query.ToList());
        }
    }
}