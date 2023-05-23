import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/search.dart';
import '../../../../core/error/failures.dart';

abstract class WeatherRepository {

  Future<Either<Failure, Weather>> getWeather(String city);
  Future<Either<Failure, List<Weather>>> getFavouriteCity(String favKey);
  Future<Either<Failure, Weather>> searchCity(String city);
}
