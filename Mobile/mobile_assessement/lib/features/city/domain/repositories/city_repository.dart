import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../entities/city.dart';

abstract class CityWeatherRepository {
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName);
}
