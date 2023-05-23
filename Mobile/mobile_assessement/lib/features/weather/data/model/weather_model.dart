import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';

class CityWeatherModel extends CityWeather {
  final String cityName;
  final double temperature;
  final double humidity;
  final String weatherDescription;
  final String time;

  CityWeatherModel({
    required this.cityName,
    required this.temperature,
    required this.humidity,
    required this.weatherDescription,
    required this.time,
  }) : super(
            cityName: '',
            countryName: '',
            temperature: 0.0,
            humidity: 0.0,
            weatherDescription: '');

  factory CityWeatherModel.fromJson(Map<String, dynamic> json) {
    return CityWeatherModel(
      cityName: json['request']['query'] ?? "",
      temperature: json['current_condition']['temp_C'].toDouble() ?? "",
      humidity: json['current_condition']['humidity'].toDouble() ?? "",
      weatherDescription: json['current_condition']['wetherDesc'][0]['value'] ?? "", time: '',
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'name': cityName,
      'sys': {'country': countryName},
      'main': {'temp': temperature, 'humidity': humidity},
      'weather': [
        {'description': weatherDescription}
      ]
    };
  }
}
