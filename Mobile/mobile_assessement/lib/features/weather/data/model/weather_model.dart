import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';

class CityWeatherModel extends CityWeather{
  final String cityName;
  final String countryName;
  final double temperature;
  final double humidity;
  final String weatherDescription;

  CityWeatherModel({
    required this.cityName,
    required this.countryName,
    required this.temperature,
    required this.humidity,
    required this.weatherDescription,
  }) : super(cityName: '', countryName: '', temperature: 0.0, humidity: 0.0, weatherDescription: '');

  factory CityWeatherModel.fromJson(Map<String, dynamic> json) {
    return CityWeatherModel(
      cityName: json['name'],
      countryName: json['sys']['country'],
      temperature: json['main']['temp'].toDouble(),
      humidity: json['main']['humidity'].toDouble(),
      weatherDescription: json['weather'][0]['description'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'name': cityName,
      'sys': {'country': countryName},
      'main': {'temp': temperature, 'humidity': humidity},
      'weather': [{'description': weatherDescription}]
    };
  }
}