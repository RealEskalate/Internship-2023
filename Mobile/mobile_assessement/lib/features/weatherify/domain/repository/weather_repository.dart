import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entity/weather_entity.dart';

abstract class WeatherRepository {
  Future<Either<Failure, Weather>> getWeatherForCity(String id);
   Future<void> saveWeather(Weather weather);
}
