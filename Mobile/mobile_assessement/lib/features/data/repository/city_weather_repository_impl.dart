import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/data/data_source/city_weather_remote_datasource.dart';

import '../../../core/error/exception.dart';
import '../../../core/error/failures.dart';
import '../../domain/entity/city_weather_entity.dart';
import '../../domain/repository/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  WeatherRemoteDataSource remotedataSource;
  

  WeatherRepositoryImpl(
      {required this.remotedataSource});

  @override
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName) async {
    
      try {
        return Right(
            (await remotedataSource.getCityWeather(cityName)) as CityWeather);
      } on ServerException {
        return Left(ServerFailure());
      } 
  }
}
