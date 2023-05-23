import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entities/city.dart';
import '../entities/weather.dart';

abstract class WeatherRepository {
  Future<Either<Failure, Weather>> getWeather(String city);
}