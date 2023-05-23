import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/exceptions.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

import '../datasources/weather_remote_datasource.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
  });
  @override
  Future<Either<Failure, Weather>> getWeather(String cityName) async {
    try {
      final remoteWeather = await remoteDataSource.getWeather(cityName);
      return Right(remoteWeather);
    } on ServerException {
      return Left(ServerFailure('Internal Server Failure'));
    }
  }
}
