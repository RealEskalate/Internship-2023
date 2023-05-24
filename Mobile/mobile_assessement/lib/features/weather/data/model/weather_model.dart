import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';

class CityWeatherModel extends CityWeather {
  final String cityName;
  final String temperature;
  final String humidity;
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
            temperature: "0.0",
            humidity: "0.0",
            weatherDescription: '');

  factory CityWeatherModel.fromJson(Map<String, dynamic> json) {
    return CityWeatherModel(
      cityName: json['request'][0]['query'] ?? "",
      temperature: json['current_condition'][0]['temp_C'] ?? "0.0",
      humidity: json['current_condition'][0]['humidity'] ?? "0.0",
      weatherDescription: json['current_condition'][0]['weatherDesc'][0]['value'] ?? "", 
      time: json["current_condition"][0]["observation_time"] ?? "",
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'name': cityName,
      'main': {'temp': temperature, 'humidity': humidity},
      'weather': [
        {'description': weatherDescription}
      ]
    };
  }
}
