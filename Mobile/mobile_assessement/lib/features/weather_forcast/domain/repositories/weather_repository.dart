import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';

import '../entities/weather.dart';
import '../entities/weather_forcast.dart';

abstract class WeatherRepository {
  Future<Either<Failure, WeatherForecast>> getWeatherForecast(String city);
  Future<Either<Failure, Weather>> getCurrentWeather(String city);
}
