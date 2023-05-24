import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_weather.dart';
import 'package:mockito/mockito.dart';

class MockWeatherRepository extends Mock implements WeatherRepository {}

void main() {
  late GetWeather useCase;
  late MockWeatherRepository mockRepository;

  setUp(() {
    mockRepository = MockWeatherRepository();
    useCase = GetWeather(repository: mockRepository);
  });

  const cityName = 'New York';

  test('should get weather for the specified city from the repository',
      () async {
    // Arrange
    Weather mockWeather = Weather(
      minTemperature: '10',
      averageTemp: '20',
      maxTemperature: '30',
      humidity: '50',
      description: 'Sunny',
    );
    when(mockRepository.getWeather("any"))
        .thenAnswer((_) async => Right(mockWeather));

    // Act
    final result = await useCase(cityName);

    // Assert
    expect(result, equals(Right(mockWeather)));
    verify(mockRepository.getWeather(cityName)).called(1);
    verifyNoMoreInteractions(mockRepository);
  });

  test('should return a failure when weather retrieval fails', () async {
    // Arrange
    final failure = ServerFailure('Failed to retrieve weather');
    when(mockRepository.getWeather("any"))
        .thenAnswer((_) async => Left(failure));

    // Act
    final result = await useCase(cityName);

    // Assert
    expect(result, equals(Left(failure)));
    verify(mockRepository.getWeather(cityName)).called(1);
    verifyNoMoreInteractions(mockRepository);
  });
}
