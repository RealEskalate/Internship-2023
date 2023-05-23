import 'package:dartz/dartz.dart';

import '../../core/error_handle/failure.dart';
import '../Entity/weather_entity.dart';

abstract class WeatherRepository {
  Future<Either<Failure, WeatherEntity>> fetchWeatherData(String city);
  }