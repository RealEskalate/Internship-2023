import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/data/datasources/weather_remote_data_source.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_model.dart';
import 'package:mockito/mockito.dart';
import 'package:http/http.dart' as http;

class MockHttpClient extends Mock implements http.Client {}

void main() {
  late RemoteWeatherDataSource remoteDataSource;
  late MockHttpClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockHttpClient();
    remoteDataSource = RemoteWeatherDataSourceImpl();
  });

  test('should fetch weather data from the API', () async {
    // Arrange
    const apiKey = '7d197f528a0548e085e123715232205';
    const city = 'London';
    final expectedWeather = WeatherModel(
      city: 'London',
      temperature: 25.0,
      humidity: 60.0,
      weatherDescription: 'Sunny',
    );

    final response = http.Response(
      '{"city":"London","temperature":25.0,"humidity":60.0,"weatherDescription":"Sunny"}',
      200,
    );
    final expectedUrl = Uri.parse('https://api.worldweatheronline.com/premium/v1/weather.ashx/?key=$apiKey&q=$city&format=JSON');
    when(mockHttpClient.get(expectedUrl)).thenAnswer((_) async => response);

    // Act
    final result = await remoteDataSource.fetchWeather(city);

    // Assert
    expect(result, equals(expectedWeather));
    verify(mockHttpClient.get(expectedUrl)).called(1);
    verifyNoMoreInteractions(mockHttpClient);
  });
}
