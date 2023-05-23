import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/weather/data/datasources/local_datasources.dart';
import 'package:mobile_assessement/features/weather/data/datasources/remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/model/weather_model.dart';
import 'package:mobile_assessement/features/weather/data/repository/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repository/weather_repository.dart';
import 'package:mockito/mockito.dart';
import 'package:mockito/annotations.dart';
import 'package:dartz/dartz.dart';

import 'weather_repository_test.mocks.dart';
// Import the generated mock classes

// Generate mock classes
@GenerateMocks([WeatherLocalDataSource, WeatherRemoteDataSource])
void main() {
  late WeatherRepository repository;
  late MockWeatherLocalDataSource mockLocalDataSource;
  late MockWeatherRemoteDataSource mockRemoteDataSource;

  setUp(() {
    mockLocalDataSource = MockWeatherLocalDataSource();
    mockRemoteDataSource = MockWeatherRemoteDataSource();
    repository = WeatherRepositoryImpl(
      localDataSource: mockLocalDataSource,
      remoteDataSource: mockRemoteDataSource,
    );
  });

  const city = 'London';

  group('getWeatherForCity', () {
    test('should return weather data from remote data source', () async {
      final weather = Weather(
        city:'Addis',
        temperature: 25,
        humidity: 80,
        description: 'Cloudy',
      );

      // Stub the remote data source method to return a weather model
      when(mockRemoteDataSource.getWeatherForCity(city))
          .thenAnswer((_) async => WeatherModel.fromJson({
                'temperature': weather.temperature,
                'humidity': weather.humidity,
                'description': weather.description,
              }));

      // Call the repository method
      final result = await repository.getWeatherForCity(city);

      // Verify that the remote data source method was called once with the correct city parameter
      verify(mockRemoteDataSource.getWeatherForCity(city));

      // Verify that the local data source method was not called
      verifyZeroInteractions(mockLocalDataSource);

      // Verify that the result is a Right value with the weather entity
      expect(result, equals(Right(weather)));

      // Verify that no other methods were called
      verifyNoMoreInteractions(mockRemoteDataSource);
      verifyNoMoreInteractions(mockLocalDataSource);
    });

    test('should return a failure when an exception occurs', () async {
      // Stub the remote data source method to throw an exception
      when(mockRemoteDataSource.getWeatherForCity(city))
          .thenThrow(Exception('Failed to fetch weather data'));

      // Call the repository method
      final result = await repository.getWeatherForCity(city);

      // Verify that the remote data source method was called once with the correct city parameter
      verify(mockRemoteDataSource.getWeatherForCity(city));

      // Verify that the local data source method was not called
      verifyZeroInteractions(mockLocalDataSource);

      // Verify that the result is a Left value with a failure object
      expect(result, equals(Left(ServerFailure())));

      // Verify that no other methods were called
      verifyNoMoreInteractions(mockRemoteDataSource);
      verifyNoMoreInteractions(mockLocalDataSource);
    });
  });
}
