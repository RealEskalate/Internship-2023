import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/exceptions.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/weather/data/datasource/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;

  WeatherRepositoryImpl({required this.remoteDataSource});

  @override
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName) async {
    try {
      final cityWeather = await remoteDataSource.getCityWeather(cityName);
      return Right(cityWeather);
    } on ServerException {
      return Left(ServerFailure());
    } on Exception {
      return Left(UnknownFailure());
    }
  }
}