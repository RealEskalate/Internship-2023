import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather_forcast/data/datasources/weather_remote_data_source.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather_forcast.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/repositories/weather_repository.dart';

import '../../domain/entities/weather.dart';

class WeatherRepositoryImplementation implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;

  WeatherRepositoryImplementation({required this.remoteDataSource});

  @override
  Future<Either<Failure, Weather>> getCurrentWeather(String city) async {
    try {
      final remoteWeather =
          await remoteDataSource.getCurrentWeather(city);
      return Right(remoteWeather);
    } on ServerException {
      return Left(ServerFailure("Server Failure"));
    }
  }

  @override
  Future<Either<Failure, WeatherForecast>> getWeatherForecast(
      String city) async {
    try {
      final remoteWeatherForecast =
          await remoteDataSource.getWeatherForecast(city);
      return Right(remoteWeatherForecast);
    } on ServerException {
      return Left(ServerFailure("Server Failure"));
    }
  }
}
