import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather_forcast.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/usecases/get_weather_forcast.dart';

import 'get_current_weather_test.mocks.dart';

void main() {
  late GetWeatherForecast usecase;
  late MockWeatherRepository mockWeatherRepository;

  setUp(() {
    mockWeatherRepository = MockWeatherRepository();
    usecase = GetWeatherForecast(repository: mockWeatherRepository);
  });

  const tLocation = 'London';
  final tWeatherForecast = WeatherForecast(forecast: [
    Weather(
        condition: 'Cloudy',
        conditionIcon: 'cloudy',
        temperature: 15.0,
        highTemperature: 20.0,
        lowTemperature: 10.0,
        windSpeed: 10.0,
        humidity: 80,
        date: DateTime.now()),
    Weather(
        condition: 'Sunny',
        conditionIcon: 'sunny',
        temperature: 20.0,
        highTemperature: 25.0,
        lowTemperature: 15.0,
        windSpeed: 5.0,
        humidity: 60,
        date: DateTime.now().add(Duration(days: 1)))
  ]);

  test(
    'should get weather forecast for the given location from the repository',
    () async {
      // arrange
      when(mockWeatherRepository.getWeatherForecast(any))
          .thenAnswer((_) async => Right(tWeatherForecast));
      // act
      final result = await usecase(tLocation);
      // assert
      expect(result, Right(tWeatherForecast));
      verify(mockWeatherRepository.getWeatherForecast(tLocation));
      verifyNoMoreInteractions(mockWeatherRepository);
    },
  );

  test(
    'should return a failure when the repository fails to retrieve data',
    () async {
      // arrange
      when(mockWeatherRepository.getWeatherForecast(any))
          .thenAnswer((_) async => Left(ServerFailure("Server Failure")));
      // act
      final result = await usecase(tLocation);
      // assert
      expect(result, Left(ServerFailure("Server Failure")));
      verify(mockWeatherRepository.getWeatherForecast(tLocation));
      verifyNoMoreInteractions(mockWeatherRepository);
    },
  );
}
