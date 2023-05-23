import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/features/weatherify/domain/repository/weather_repository.dart';
import 'package:mockito/annotations.dart';

@GenerateMocks([WeatherRepository])

void main() {
  // MockWeatherRepository mockWeatherRepository;
  // Weather weather = Weather(cityName: 'New York', temperature: 20, description: '', humidity: null);

  setUp(() {
    // mockWeatherRepository = MockWeatherRepository();
  });

  // test('should get weather for city from repository', () async {
  //   when(mockWeatherRepository.getWeatherForCity(any))
  //       .thenAnswer((_) async => Right(weather));

  //   final result = await mockWeatherRepository.getWeatherForCity('1');

  //   expect(result, Right(weather));
  //   verify(mockWeatherRepository.getWeatherForCity('1'));
  //   verifyNoMoreInteractions(mockWeatherRepository);
  // });

  // test('should save weather to repository', () async {
  //   await mockWeatherRepository.saveWeather(weather);

  //   verify(mockWeatherRepository.saveWeather(weather));
  //   verifyNoMoreInteractions(mockWeatherRepository);
  // });
}