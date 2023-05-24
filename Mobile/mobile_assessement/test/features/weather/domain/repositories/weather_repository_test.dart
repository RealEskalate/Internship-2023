import 'package:dartz/dartz.dart';
import 'package:http/http.dart' as http;
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

void main() {
  late WeatherRepository repository;

  setUp(() {
    repository = WeatherRepositoryImpl(
        remoteDataSource: WeatherRemoteDataSourceImpl(
            client:
                http.Client())); // Replace with your repository implementation
  });

  const cityName = 'New York';

  group('WeatherRepository', () {
    test('should retrieve weather for the specified city', () async {
      // Arrange

      // Act
      final result = await repository.getWeather(cityName);

      // Assert
      expect(result, isA<Right<Failure, Weather>>());
      // Additional assertions based on the expected behavior
    });

    test('should return a failure when weather retrieval fails', () async {
      // Arrange

      // Act
      final result = await repository.getWeather(cityName);

      // Assert
      expect(result, isA<Left<Failure, Weather>>());
      // Additional assertions based on the expected behavior
    });
  });
}
