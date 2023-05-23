
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/domain/repository/weather_repository.dart';
import 'package:mockito/annotations.dart';
// import 'package:mocki';

@GenerateMocks([WeatherRepository])

void main(){
//   late MockWeatherRepository mockWeatherRepository;
//   late GetCityWeatherUseCase usecase;
//   setUp(() {
//     mockWeatherRepository = MockWeatherRepository();
//     usecase = GetCityWeatherUseCase(repository: mockWeatherRepository);
//   });
  
//   final CityWeather cityWeather = CityWeather(cityName: 'Lagos', temperature: 30, weatherType: 'Sunny', lastUpdated: DateTime.now());
//   const String cityName = "Lagos";
//   test ('should get city weather detail', ()async {
//     when(mockWeatherRepository.getCityWeather(cityName)).thenAnswer((_) async => Right(cityWeather));

//     final result = await usecase(cityName);

//     expect(result, Right(cityWeather));
//     verify(mockWeatherRepository.getCityWeather(cityName));
//     verifyNoMoreInteractions(mockWeatherRepository);
//   });
}

