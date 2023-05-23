import 'dart:js_interop';

import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/exception.dart';

import '../../../../core/error/failures.dart';
import '../../domain/repository/weather_repository.dart';
import '../datasources/local_datasources.dart';
import '../datasources/remote_datasource.dart';
import '../model/weather_model.dart';

class WeatherRepositoryImpl extends WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;
  final WeatherLocalDataSource localDataSource;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
  });

  @override
  Future<Either<Failure, WeatherModel>> getWeatherForCity(String city) async {
    try {
      final weather = await remoteDataSource.getWeatherForCity(city);
      localDataSource.cacheWeatherData(weather);
      return Right(weather);
    } on ServerException {
      try{

      final cachedWeather = await localDataSource.getCachedWeatherData(city);
      if (!cachedWeather.isNull) {
        return Right(cachedWeather);
      } 
      } on CacheException{
        return Left(CacheFailure());
      }
      }
        return Left(ServerFailure());
      }
    


  @override
  Future<Either<Failure, List<WeatherModel>>> getFavoriteWeather() async {
    final favoriteCities = await localDataSource.getFavoriteCities();
    final favoriteWeather = <WeatherModel>[];

    for (final city in favoriteCities) {
      try {
        final weather = await remoteDataSource.getWeatherForCity(city);
        favoriteWeather.add(weather);
      } catch (e) {
        // Ignore any exceptions and continue to the next city
      }
    }

    return Right(favoriteWeather);
  }

  @override
  Future<void> saveFavoriteCity(String city) async {
    await localDataSource.addFavoriteCity(city);
  }

  @override
  Future<void> removeFavoriteCity(String city) async {
    await localDataSource.removeFavoriteCity(city);
  }
}

  