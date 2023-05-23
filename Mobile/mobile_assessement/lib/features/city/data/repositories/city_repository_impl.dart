import 'package:dartz/dartz.dart';

import '../../../../core/error/exception.dart';
import '../../../../core/error/failures.dart';
import '../../domain/entities/city.dart';
import '../../domain/repositories/city_repository.dart';
import '../datasources/city_remote_datasources.dart';

class CityWeatherRepositoryImpl implements CityWeatherRepository {
  final CityWeatherRemoteDataSource remoteDataSource;

  CityWeatherRepositoryImpl({required this.remoteDataSource});

  @override
  Future<Either<Failure, CityWeather>> getCityWeather(String cityName) async {
    try {
      final cityWeatherModel = await remoteDataSource.getCityWeather(cityName);
      final cityWeather = CityWeather(
        cityName: cityWeatherModel.cityName,
        oldestDate: cityWeatherModel.oldestDate,
        avgTempc: cityWeatherModel.avgTempc,
      );
      return Right(cityWeather);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
