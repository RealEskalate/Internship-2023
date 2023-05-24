import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';

void main() {
  const mockJson = {
    'data': {
      'current_condition': [
        {'temp_C': '25', 'temp_F': '77', 'humidity': '70'}
      ],
      'weather': [
        {'maxtempC': '30', 'mintempC': '20'}
      ]
    }
  };

  test('should create a valid WeatherModel from JSON', () {
    // Arrange
    WeatherModel expectedWeather = WeatherModel(
      minTemperature: '20',
      averageTemp: '25',
      maxTemperature: '30',
      humidity: '70',
      description: '',
    );

    // Act
    final weather = WeatherModel.fromJson(mockJson);

    // Assert
    expect(weather, equals(expectedWeather));
  });

  test('toJson should return a JSON map with proper values', () {
    // Arrange
    final weather = WeatherModel(
      minTemperature: '20',
      averageTemp: '25',
      maxTemperature: '30',
      humidity: '70',
      description: '',
    );

    // Act
    final jsonMap = weather.toJson();

    // Assert
    expect(jsonMap['minTemperature'], equals('20'));
    expect(jsonMap['maxTemperature'], equals('30'));
    expect(jsonMap['description'], equals(''));
    expect(jsonMap['humidity'], equals('70'));
  });
}
