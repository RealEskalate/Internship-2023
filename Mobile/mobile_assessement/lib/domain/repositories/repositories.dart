import 'package:dartz/dartz.dart';

import '../../core/errors/failur.dart';
import '../entities/weather.dart';



abstract class WeatherRepository {
  Future<Either<Failure, Weather>> getWeatherByCity(String city);
}
