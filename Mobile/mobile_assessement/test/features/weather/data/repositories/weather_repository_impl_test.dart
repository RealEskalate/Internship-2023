import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/core/exceptions.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mockito/mockito.dart';

class MockWeatherRemoteDataSource extends Mock
    implements WeatherRemoteDataSource {}

void main() {
  late WeatherRepositoryImpl repository;
  late MockWeatherRemoteDataSource mockRemoteDataSource;

  setUp(() {
    mockRemoteDataSource = MockWeatherRemoteDataSource();
    repository = WeatherRepositoryImpl(remoteDataSource: mockRemoteDataSource);
  });

  group('getWeather', () {
    const cityName = 'New York';

    test('should return Weather when the request is successful', () async {
      // Arrange
      final mockWeatherModel = WeatherModel(
        minTemperature: '10',
        averageTemp: '20',
        maxTemperature: '30',
        humidity: '70',
        description: 'Sunny',
      );
      final expectedWeather = mockWeatherModel; // Adjust based on your Weather class
      when(mockRemoteDataSource.getWeather(cityName))
          .thenAnswer((_) async => mockWeatherModel);

      // Act
      final result = await repository.getWeather(cityName);

      // Assert
      expect(result, equals(Right(expectedWeather)));
    });

    test('should return a failure when the request fails', () async {
      // Arrange
      when(mockRemoteDataSource.getWeather(cityName))
          .thenThrow(ServerException("failed"));

      // Act
      final result = await repository.getWeather(cityName);

      // Assert
      expect(result, equals(Left(ServerFailure('Internal Server Failure'))));
    });
  });
}
