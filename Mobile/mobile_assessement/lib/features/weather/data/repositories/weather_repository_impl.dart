import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/exceptions.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/weather/data/datasource/weather_local_datasource.dart';
import 'package:mobile_assessement/features/weather/data/datasource/weather_remote_datasource.dart';
import 'package:mobile_assessement/features/weather/domain/entity/weather.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;
  final WeatherLocalDataSource localDataSource;

  WeatherRepositoryImpl({required this.localDataSource, required this.remoteDataSource});

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

  @override
  Future<Either<Failure, List<String>>> getFavoriteCities() async {
    try {
      final favoriteCities = await localDataSource.getFavoriteCities();
      return Right(favoriteCities);
    } catch (_) {
      return Left(UnknownFailure());
    }
  }

  @override
  Future<Either<Failure, void>> addFavoriteCity(String cityName) async {
    try {
      await localDataSource.addFavoriteCity(cityName);
      return const Right(null);
    } catch (_) {
      return Left(UnknownFailure());
    }
  }

  @override
  Future<Either<Failure, void>> removeFavoriteCity(String cityName) async {
    try {
      await localDataSource.removeFavoriteCity(cityName);
      return const Right(null);
    } catch (_) {
      return Left(UnknownFailure());
    }
  }
}
