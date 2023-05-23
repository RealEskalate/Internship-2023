import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../entities/city.dart';
import '../entities/city_weather.dart';

abstract class WeatherRepository {
  // Future<Either<Failure, List<City>>> getCities();

  Future<Either<Failure, CityWeatherDetail>> getCityWeather(String cityName);
}
