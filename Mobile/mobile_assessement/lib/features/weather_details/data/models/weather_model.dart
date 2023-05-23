import 'package:mobile_assessement/features/weather_details/domain/entities/weather.dart';

class WeatherModel extends Weather {
  WeatherModel({
    required String date,
    required String condition,
    required String temperature,
    required String humidity,
    required String windSpeed,
  }) : super(
          date: date,
          condition: condition,
          temperature: temperature,
          humidity: humidity,
          windSpeed: windSpeed,
        );
}
