import '../../domain/entities/city_weather.dart';

class CityWeatherDetailModel extends CityWeatherDetail {
  CityWeatherDetailModel({
    required super.cityName,
    required super.currentCondition,
    required super.currentConditionImage,
    required super.currentTempC,
    required super.forecastList,
  });

  factory CityWeatherDetailModel.fromJson(Map<String, dynamic> json) {
    final currentConditionJson = json['current_condition'][0];
    final forecastJson = json['weather'];
    return CityWeatherDetailModel(
      currentConditionImage: currentConditionJson['weatherIconUrl'][0]['value'] ?? "",
      cityName: json['request'][0]['query'].toString(),
      currentCondition: currentConditionJson['weatherDesc'][0]['value'] ?? "",
      currentTempC: currentConditionJson['temp_C'] ?? "",
      forecastList: List<WeatherForecastModel>.from(forecastJson.map((obj) {
        return WeatherForecastModel.fromJson(obj);
      })),
    );
  }
}

class WeatherForecastModel extends WeatherForecast {
  WeatherForecastModel({
    required String date,
    required String maxTempC,
    required String minTempC,
    required String image,
  }) : super(
          date: date,
          maxTempC: maxTempC,
          minTempC: minTempC,
          image: image,
        );

  factory WeatherForecastModel.fromJson(Map<String, dynamic> json) {
    return WeatherForecastModel(
      date: json['date'],
      maxTempC: json['mintempC'],
      minTempC: json['maxtempC'],
      image: json['hourly'][0]['weatherIconUrl'][0]['value'] ?? "",
    );
  }
}
