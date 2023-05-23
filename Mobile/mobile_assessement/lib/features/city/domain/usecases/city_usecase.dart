import 'package:dartz/dartz.dart';
import '../../../../core/error/failures.dart';
import '../entities/city.dart';
import '../repositories/city_repository.dart';

class GetCityWeather {
  final CityWeatherRepository repository;

  GetCityWeather(this.repository);

  Future<Either<Failure, CityWeather>> call(String cityName) async {
    return await repository.getCityWeather(cityName);
  }
}
