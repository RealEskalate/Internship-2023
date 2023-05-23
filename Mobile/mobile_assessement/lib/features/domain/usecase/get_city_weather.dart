import 'package:dartz/dartz.dart';

import '../../../core/error/failures.dart';
import '../../../core/usecase/usecase.dart';
import '../entity/city_weather_entity.dart';
import '../repository/weather_repository.dart';

class GetCityWeatherUseCase implements UseCase<CityWeather, String> {
  final WeatherRepository repository;

  @override
  Future<Either<Failure, CityWeather>> call(String cityName) async {
    return await repository.getCityWeather(cityName);
  }

  GetCityWeatherUseCase(this.repository);
}
