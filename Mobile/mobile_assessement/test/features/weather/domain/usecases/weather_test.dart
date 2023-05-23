import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repo.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_fav_city.dart';

@GenerateMocks([WeatherRepository])
void main() {
  late GetWeather usecase;
  // late MockWeatherRepository mockWeatherRepository;

  // setUp(() {
  //   mockWeatherRepository = MockWeatherRepository();
  //   usecase = GetWeather(mockWeatherRepository);
  // });
  final tcity = "city";
  final ttemprature = 12.0;
  final tdescription = "description";
  final tfavKey = "favKey";

  final tWeather = Weather(
    city: tcity,
    temprature: ttemprature,
    description: tdescription,
    favKey: tfavKey,
  );

  // test(
  //   'should get Weather',
  //   () async {
  //     when(mockWeatherRepository.getWeather(tcity))
  //         .thenAnswer((_) async => Right(tWeather));

  //     final result = await usecase.call(tcity);
  //     // assert
  //     expect(result, Right(tWeather));
  //     verify(mockWeatherRepository.getWeather(tcity));
  //     verifyNoMoreInteractions(mockWeatherRepository);
  //   },
  // );
}
