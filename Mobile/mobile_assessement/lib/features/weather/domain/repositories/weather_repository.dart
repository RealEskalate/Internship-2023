

import 'package:dartz/dartz.dart';
import '../../../../core/error/failures.dart';
import '../entities/weather_detail_domain.dart';
abstract class WeatherRepository {

  Future<Either<Failure, TemperatureData>> getWeather(String id);
}