import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mockito/mockito.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usecase/search_weather.dart';

class MockWeatherRepository extends Mock implements WeatherRepository {}

void main() {
  late SearchWeather useCase;
  late MockWeatherRepository mockWeatherRepository;

  setUp(() {
    mockWeatherRepository = MockWeatherRepository();
    useCase = SearchWeather(mockWeatherRepository);
  });

  test('should return weather for a given city', () async {
    // Arrange
    final city = 'London';
    final weather = Weather(
      city: city,
      temperature: 25.0,
      humidity: 60.0,
      weatherDescription: 'Sunny',
    );
    when(mockWeatherRepository.fetchWeather(city))
        .thenAnswer((_) async => weather);

    // Act
    final result = await useCase.execute(city);

    // Assert
    expect(result, equals(weather));
    verify(mockWeatherRepository.fetchWeather(city)).called(1);
    verifyNoMoreInteractions(mockWeatherRepository);
  });

  test('should throw an exception if weather fetch fails', () async {
    // Arrange
    final city = 'London';
    when(mockWeatherRepository.fetchWeather(city))
        .thenThrow(Exception('Failed to fetch weather data'));

    // Act
    final result = useCase.execute(city);

    // Assert
    expect(result, throwsException);
    verify(mockWeatherRepository.fetchWeather(city)).called(1);
    verifyNoMoreInteractions(mockWeatherRepository);
  });
}
