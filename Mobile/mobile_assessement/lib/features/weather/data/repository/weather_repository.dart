import 'package:dartz/dartz.dart';

import '../../../../core/error/exceptions.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/city.dart';
import '../../domain/entities/city_weather.dart';
import '../../domain/repository/weather_repository.dart';
import '../datasource/weather_local_datasource.dart';
import '../datasource/weather_remote_datasource.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;
  final WeatherLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
    required this.networkInfo,
  });

  // @override
  // Future<Either<Failure, List<City>>> getCities() async {
  //   if (await networkInfo.isConnected) {
  //     try {
  //       final cities = await localDataSource.getCities();
  //       return Right(cities);
  //     } on ServerException {
  //       return Left(ServerFailure());
  //     }
  //   } else {
  //     return Left(CacheFailure());
  //   }
  // }

  @override
  Future<Either<Failure, CityWeatherDetail>> getCityWeather(
      String cityName) async {
    if (await networkInfo.isConnected) {
      try {
        final cityWeather = await remoteDataSource.getCityWeather(cityName);
        print(cityWeather);
        print("repo");
        return Right(cityWeather);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
