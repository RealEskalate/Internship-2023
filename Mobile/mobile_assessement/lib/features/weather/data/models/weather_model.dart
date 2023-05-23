import '../../domain/entities/weather.dart';

class WeatherModel extends Weather {
  WeatherModel({
    required String city,
    required double temperature,
    required double humidity,
    required String weatherDescription,
  }) : super(
          city: city,
          temperature: temperature,
          humidity: humidity,
          weatherDescription: weatherDescription,
        );

  factory WeatherModel.fromJson(Map<String, dynamic> json) {
    return WeatherModel(
      city: json['city'],
      temperature: json['temperature'].toDouble(),
      humidity: json['humidity'].toDouble(),
      weatherDescription: json['weather_description'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'city': city,
      'temperature': temperature,
      'humidity': humidity,
      'weather_description': weatherDescription,
    };
  }
}