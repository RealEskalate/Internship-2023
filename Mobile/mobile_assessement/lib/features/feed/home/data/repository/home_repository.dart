import 'package:mobile_assessement/core/error/exception.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/feed/home/data/datasource/home_remote.dart';
import 'package:mobile_assessement/features/feed/home/domain/entity/home.dart';
import 'package:mobile_assessement/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';

class HomeRepositoryImpl implements HomeRepository {
  final HomeRemoteDataSource homeRemoteDataSource;
  HomeRepositoryImpl({required this.homeRemoteDataSource});
  @override
  Future<Either<Failure, Home>> search(String city) async {
    final response = await homeRemoteDataSource.search(city);
    try {
      return Right(response);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}