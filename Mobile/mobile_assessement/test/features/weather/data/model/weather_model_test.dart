import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/data/model/weather_model.dart';

void main() {
  group('WeatherModel', () {
    const double temperature = 25;
    const double humidity = 80;
    const String description = 'Cloudy';
    const String city = 'Addis';

    test('should create a WeatherModel instance', () {
      final weatherModel = WeatherModel(
        city: city,
        temperature: temperature,
        humidity: humidity,
        description: description,
      );

      expect(weatherModel.temperature, temperature);
      expect(weatherModel.humidity, humidity);
      expect(weatherModel.description, description);
    });

    test('should convert WeatherModel to JSON', () {
      final weatherModel = WeatherModel(
        city: city,
        temperature: temperature,
        humidity: humidity,
        description: description,
      );

      final json = weatherModel.toJson();

      expect(json['temperature'], temperature);
      expect(json['humidity'], humidity);
      expect(json['description'], description);
    });

    test('should create WeatherModel from JSON', () {
      final json = {
        'city':city,
        'temperature': temperature,
        'humidity': humidity,
        'description': description,
      };

      final weatherModel = WeatherModel.fromJson(json);

      expect(weatherModel.temperature, temperature);
      expect(weatherModel.humidity, humidity);
      expect(weatherModel.description, description);
    });
  });
}
