import 'package:dartz/dartz.dart';

import '../../core/errors/failur.dart';
import '../../core/network/network_info.dart';
import '../../domain/entities/weather.dart';
import '../../domain/repositories/repositories.dart';
import '../datasources/remote_data_souce.dart';



class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, Weather>> getWeatherByCity(String city) async {
    // if (await networkInfo.isConnected) {
      try {
        final weatherModel = await remoteDataSource.getWeatherByCity(city);
        final weather = Weather(
          city: weatherModel.city,
          temperature: weatherModel.temperature,
          dateTime: weatherModel.dateTime,
        );
        return Right(weather);
      } catch (e) {
        return Left(ServerFailure("Server Failed"));
      }
    // } else {
    //   return Left(NetworkFailure("Network error"));
    // }
  }
}
