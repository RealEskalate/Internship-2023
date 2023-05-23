import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../data/model/weather_model.dart';
abstract class WeatherRepository {
  Future<Either<Failure, WeatherModel>> getWeatherForCity(String city);
  Future<Either<Failure, List<WeatherModel>>> getFavoriteWeather();
  Future<void> saveFavoriteCity(String city);
  Future<void> removeFavoriteCity(String city);
}
