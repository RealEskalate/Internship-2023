import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/core/exceptions.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';
import 'package:mockito/mockito.dart';

class MockHttpClient extends Mock implements http.Client {}

void main() {
  late WeatherRemoteDataSourceImpl dataSource;
  late MockHttpClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockHttpClient();
    dataSource = WeatherRemoteDataSourceImpl(client: mockHttpClient);
  });

  group('getWeather', () {
    const cityName = 'New York';

    test('should return WeatherModel when the request is successful', () async {
      // Arrange
      final mockResponse = '''
        {
          "data": {
            "current_condition": [
              {
                "temp_C": "25",
                "temp_F": "77",
                "humidity": "70"
              }
            ],
            "weather": [
              {
                "maxtempC": "30",
                "mintempC": "20"
              }
            ]
          }
        }
      ''';
      final expectedWeather = WeatherModel(
        minTemperature: '20',
        averageTemp: '25',
        maxTemperature: '30',
        humidity: '70',
        description: '',
      );

      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response(mockResponse, 200));

      // Act
      final result = await dataSource.getWeather(cityName);

      // Assert
      expect(result, equals(expectedWeather));
    });

    test('should throw a ServerException when the request fails', () async {
      // Arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response('Error', 500));

      // Act
      final call = dataSource.getWeather;

      // Assert
      expect(() => call(cityName), throwsA(isA<ServerException>()));
    });
  });
}
