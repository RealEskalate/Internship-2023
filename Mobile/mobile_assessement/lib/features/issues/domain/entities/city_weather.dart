class CityWeatherDetail {
  final String cityName;
  final String currentCondition;
  final String currentConditionImage;
  final String currentTempC;
  final List<WeatherForecast> forecastList;

  CityWeatherDetail({
    required this.cityName,
    required this.currentCondition,
    required this.currentTempC,
    required this.forecastList,
    required this.currentConditionImage,
  });
}

class WeatherForecast {
  final String date;
  final String maxTempC;
  final String minTempC;
  final String image;

  WeatherForecast({
    required this.date,
    required this.maxTempC,
    required this.minTempC,
    required this.image,
  });
}
