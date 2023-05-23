import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/repositories/weather_repository.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/usecases/get_current_weather.dart';

import 'get_current_weather_test.mocks.dart';

@GenerateMocks([WeatherRepository])
void main() {
  late GetCurrentWeather usecase;
  late MockWeatherRepository mockWeatherRepository;

  setUp(() {
    mockWeatherRepository = MockWeatherRepository();
    usecase = GetCurrentWeather(repository: mockWeatherRepository);
  });

  const tLocation = "London";
  final tWeather = Weather(
      condition: 'Cloudy',
      conditionIcon: 'cloudy',
      temperature: 15.0,
      highTemperature: 20.0,
      lowTemperature: 10.0,
      windSpeed: 10.0,
      humidity: 80,
      date: DateTime.now());

  test(
    'should get current weather for the given location from the repository',
    () async {
      // arrange
      when(mockWeatherRepository.getCurrentWeather(any))
          .thenAnswer((_) async => Right(tWeather));
      // act
      final result = await usecase(tLocation);
      // assert
      expect(result, Right(tWeather));
      verify(mockWeatherRepository.getCurrentWeather(tLocation));
      verifyNoMoreInteractions(mockWeatherRepository);
    },
  );

  test(
    'should return a failure when the repository fails to retrieve data',
    () async {
      // arrange
      when(mockWeatherRepository.getCurrentWeather(any))
          .thenAnswer((_) async => Left(ServerFailure("Server Failure")));
      // act
      final result = await usecase(tLocation);
      // assert
      expect(result, Left(ServerFailure("Server Failure")));
      verify(mockWeatherRepository.getCurrentWeather(tLocation));
      verifyNoMoreInteractions(mockWeatherRepository);
    },
  );
}
