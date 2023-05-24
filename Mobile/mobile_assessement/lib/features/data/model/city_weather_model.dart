
import '../../domain/entity/city_weather_entity.dart';

class WeatherModel extends CityWeather {
  const WeatherModel({
    required String cityName,
    required double temperature,
    required double humidity,
    required String weatherDescription,
  }) : super(
          cityName: cityName,
          temperature: temperature,
          humidity: humidity,
          weatherDescription: weatherDescription,
        );

  factory WeatherModel.fromJson(Map<String, dynamic> json) {

    return WeatherModel(
      cityName: json['cityName'],
      temperature: json['temperature'],
      humidity: json['humidity'],
      weatherDescription: json['weatherDescription'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'cityName' : cityName, 
      'temperature' : temperature, 
      "humidity": humidity,
      "weatherDescription": weatherDescription, 
    };
  }
}
