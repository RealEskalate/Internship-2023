import 'dart:convert';

import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:http/http.dart' as http;
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/features/weather_forcast/data/datasources/weather_remote_data_source.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_forcast_model.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_model.dart';

import 'weather_remote_data_source_test.mocks.dart';

@GenerateMocks([http.Client])
void main() {
  late WeatherRemoteDataSourceImplementation dataSource;
  late MockClient mockHttpClient;

  setUp(() {
    mockHttpClient = MockClient();
    dataSource = WeatherRemoteDataSourceImplementation(client: mockHttpClient);
  });

  group('getCurrentWeather', () {
    const location = 'London';
    final weatherModel = WeatherModel(
      condition: 'Clouds',
      conditionIcon: '04d',
      temperature: 280.32,
      highTemperature: 281.15,
      lowTemperature: 279.15,
      windSpeed: 4.6,
      humidity: 81,
      date: DateTime.fromMillisecondsSinceEpoch(1638362400 * 1000),
    );

    test(
        'should perform a GET request on a URL with city being the endpoint and with application/json header',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers'))).thenAnswer(
          (_) async => http.Response(json.encode(weatherModel.toJson()), 200));
      // act
      dataSource.getCurrentWeather(location);
      // assert
      verify(mockHttpClient.get(
        Uri.parse(
            'https://api.openweathermap.org/data/2.5/weather?q=London&appid=b0af9f62d335367e413b20b54012b91b'),
        headers: {'Content-Type': 'application/json'},
      ));
    });

    test('should return WeatherModel when the response code is 200 (success)',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers'))).thenAnswer(
          (_) async => http.Response(json.encode(weatherModel.toJson()), 200));
      // act
      final result = await dataSource.getCurrentWeather(location);
      // assert
      expect(result, equals(weatherModel));
    });

    test('should throw a ServerException when the response code is not 200',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response('Something went wrong', 404));
      // act
      final call = dataSource.getCurrentWeather;
      // assert
      expect(() => call(location), throwsA(isInstanceOf<ServerException>()));
    });
  });

  group('getWeatherForecast', () {
    const location = 'London';
    final weatherForecastModel = WeatherForecastModel(forecast: [
      WeatherModel(
        condition: 'Clouds',
        conditionIcon: '04d',
        temperature: 280.32,
        highTemperature: 281.15,
        lowTemperature: 279.15,
        windSpeed: 4.6,
        humidity: 81,
        date: DateTime.fromMillisecondsSinceEpoch(1638362400 * 1000),
      ),
      WeatherModel(
        condition: 'Rain',
        conditionIcon: '10d',
        temperature: 279.26,
        highTemperature: 279.82,
        lowTemperature: 278.15,
        windSpeed: 6.17,
        humidity: 87,
        date: DateTime.fromMillisecondsSinceEpoch(1638399600 * 1000),
      ),
    ]);

    test(
        'should perform a GET request on a URL with city being the endpoint and with application/json header',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers'))).thenAnswer(
          (_) async =>
              http.Response(json.encode(weatherForecastModel.toJson()), 200));
      // act
      dataSource.getWeatherForecast(location);
      // assert
      verify(mockHttpClient.get(
        Uri.parse(
            'https://api.openweathermap.org/data/2.5/forecast?q=London&appid=b0af9f62d335367e413b20b54012b91b'),
        headers: {'Content-Type': 'application/json'},
      ));
    });

    test(
        'should return WeatherForecastModel when the response code is 200 (success)',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers'))).thenAnswer(
          (_) async =>
              http.Response(json.encode(weatherForecastModel.toJson()), 200));
      // act
      final result = await dataSource.getWeatherForecast(location);
      // assert
      expect(result, equals(weatherForecastModel));
    });

    test('should throw a ServerException when the response code is not 200',
        () async {
      // arrange
      when(mockHttpClient.get(any, headers: anyNamed('headers')))
          .thenAnswer((_) async => http.Response('Something went wrong', 404));
      // act
      final call = dataSource.getWeatherForecast;
      // assert
      expect(() => call(location), throwsA(isInstanceOf<ServerException>()));
    });
  });
}
