import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';

void main() {
  test('WeatherModel should be created from JSON', () {
    // Arrange
    final json = {
      'city': 'London',
      'temperature': 25.0,
      'humidity': 60.0,
      'weather_description': 'Sunny',
    };

    // Act
    final weatherModel = WeatherModel.fromJson(json);

    // Assert
    expect(weatherModel.city, 'London');
    expect(weatherModel.temperature, 25.0);
    expect(weatherModel.humidity, 60.0);
    expect(weatherModel.weatherDescription, 'Sunny');
  });

  test('WeatherModel should be converted to JSON', () {
    // Arrange
    final weatherModel = WeatherModel(
      city: 'London',
      temperature: 25.0,
      humidity: 60.0,
      weatherDescription: 'Sunny',
    );

    // Act
    final json = weatherModel.toJson();

    // Assert
    expect(json['city'], 'London');
    expect(json['temperature'], 25.0);
    expect(json['humidity'], 60.0);
    expect(json['weather_description'], 'Sunny');
  });
}
