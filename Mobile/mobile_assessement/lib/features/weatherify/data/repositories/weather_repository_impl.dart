import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/core/errors/failure.dart';
import 'package:mobile_assessement/features/weatherify/data/datasources/weatherify_remote_data_source.dart';
import 'package:mobile_assessement/features/weatherify/domain/entities/weather.dart';
import 'package:mobile_assessement/features/weatherify/domain/repositories/weatherify_repository.dart';

class WeatherifyRepositoryImpl implements WeatherifyRepository {
  final WeatherifyRemoteDataSource remoteDataSource;

  WeatherifyRepositoryImpl({
    required this.remoteDataSource,
  });

  @override
  Future<Either<Failure, Weather>> searchCity(String cityName) async {
    try {
      final user = await remoteDataSource.searchCity(cityName);
      return Right(user);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }
}
