import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/domain/entity/city_weather_entity.dart';

abstract class WeatherRepository {
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName);
}
