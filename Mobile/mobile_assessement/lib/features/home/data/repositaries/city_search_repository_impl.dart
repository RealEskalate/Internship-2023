import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/exceptions.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/network/network_info.dart';
import 'package:mobile_assessement/features/home/data/datasources/city_search_remote_data_source.dart';
import 'package:mobile_assessement/features/home/domain/entities/city.dart';
import 'package:mobile_assessement/features/home/domain/repositories/city_search_repository.dart';

abstract class CitySearchRepository {
  Future<Either<Failure, City>> searchCity(String cityName);
}

class CitySearchRepositoryImpl implements CitySearchRepository {
  final CitySearchRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  CitySearchRepositoryImpl({
    required this.remoteDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, City>> searchCity(String cityName) async {
    if (await networkInfo.isConnected) {
      try {
        final cityModel = await remoteDataSource.searchCity(cityName);
        return Right(cityModel);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
