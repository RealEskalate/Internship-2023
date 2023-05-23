import 'package:mobile_assessement/core/error/exception.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/feed/detail/domain/entity/detail.dart';
import 'package:mobile_assessement/features/feed/home/data/datasource/home_remote.dart';
import 'package:mobile_assessement/features/feed/home/domain/entity/home.dart';
import 'package:mobile_assessement/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';

import '../../domain/repository/home_detail_repository.dart';
import '../datasources/home_detail_remote.dart';

class HomeDetailRepositoryImpl implements HomeDetailRepository {
  final HomeDetailRemoteDataSource homeDetailRemoteDataSource;
  HomeDetailRepositoryImpl({required this.homeDetailRemoteDataSource});
  @override
  Future<Either<Failure, HomeDetail>> getWeather(String city) async {
    final response = await homeDetailRemoteDataSource.GetWeather(city);
    try {
      return Right(response);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}