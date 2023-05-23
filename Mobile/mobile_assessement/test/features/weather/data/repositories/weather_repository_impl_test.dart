import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_local_data_source.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_data_source.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';
import 'package:mobile_assessement/features/weather/data/repositories/weather_repository_impl.dart';
import 'package:mockito/mockito.dart';


class MockRemoteWeatherDataSource extends Mock
    implements RemoteWeatherDataSource {}

class MockLocalWeatherDataSource extends Mock implements LocalWeatherDataSource {}

void main() {
  late WeatherRepositoryImpl repository;
  late MockRemoteWeatherDataSource mockRemoteDataSource;
  late MockLocalWeatherDataSource mockLocalDataSource;

  setUp(() {
    mockRemoteDataSource = MockRemoteWeatherDataSource();
    mockLocalDataSource = MockLocalWeatherDataSource();
    repository = WeatherRepositoryImpl(
      remoteDataSource: mockRemoteDataSource,
      localDataSource: mockLocalDataSource,
    );
  });

  group('fetchWeather', () {
    const city = 'London';
    final weather = WeatherModel(
      city: city,
      temperature: 25.0,
      humidity: 60.0,
      weatherDescription: 'Sunny',
    );

    test('should return weather from local data source if available', () async {
      // Arrange
      when(mockLocalDataSource.getWeather(city)).thenAnswer((_) async => weather);

      // Act
      final result = await repository.fetchWeather(city);

      // Assert
      expect(result, equals(weather));
      verify(mockLocalDataSource.getWeather(city)).called(1);
      verifyZeroInteractions(mockRemoteDataSource);
      verifyZeroInteractions(mockLocalDataSource.saveWeather);
      verifyZeroInteractions(mockRemoteDataSource.fetchWeather);
    });

    test('should return weather from remote data source if not available locally', () async {
      // Arrange
      when(mockLocalDataSource.getWeather(city)).thenAnswer((_) async => null);
      when(mockRemoteDataSource.fetchWeather(city)).thenAnswer((_) async => weather);
      when(mockLocalDataSource.saveWeather(weather)).thenAnswer((_) async {});

      // Act
      final result = await repository.fetchWeather(city);

      // Assert
      expect(result, equals(weather));
      verify(mockLocalDataSource.getWeather(city)).called(1);
      verify(mockRemoteDataSource.fetchWeather(city)).called(1);
      verify(mockLocalDataSource.saveWeather(weather)).called(1);
    });
  });
}
