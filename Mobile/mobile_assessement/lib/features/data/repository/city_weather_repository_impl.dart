import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/data/data_source/city_weather_remote_datasource.dart';

import '../../../core/error/exception.dart';
import '../../../core/error/failures.dart';
import '../../../core/network/network_info.dart';
import '../../domain/entity/city_weather_entity.dart';
import '../../domain/repository/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  WeatherRemoteDataSource remotedataSource;
  NetworkInfo networkInfo;

  WeatherRepositoryImpl(
      {required this.remotedataSource, required this.networkInfo});

  @override
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName) async {
    
    if (await networkInfo.isConnected) {
      try {
        return Right(
            (await remotedataSource.getCityWeather(cityName)) as CityWeather);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
