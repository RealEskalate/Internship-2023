import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_weather.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/repositories/weather_repo.dart';
import '../datasources/weather_remote_datasource.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource weatherRemoteDataSource;
  final NetworkInfo networkInfo;

  WeatherRepositoryImpl(
      {required this.weatherRemoteDataSource, required this.networkInfo});

  @override
  Future<Either<Failure, Weather>> GetWeather(String city) async {
    final networkStatus = await networkInfo.isConnected;
    try {
      if (!networkStatus){
        return Left(ServerFailure());
      }
      final weather = await weatherRemoteDataSource.getWeather(city);
      return Right(weather);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
