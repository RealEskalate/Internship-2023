import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/home/data/datasource/home_remote.dart';
import 'package:dartsmiths/features/home/domain/entity/home.dart';
import 'package:dartsmiths/features/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';

class HomeRepositoryImpl implements HomeRepository {
  final HomeRemoteDataSource homeRemoteDataSource;
  HomeRepositoryImpl({required this.homeRemoteDataSource});
  @override
  Future<Either<Failure, Home>> filterByTag(String tag) async {
    final response = await homeRemoteDataSource.filterByTag(tag);
    try {
      return Right(response);
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Home>> search(String term, String tag) async {
    final response = await homeRemoteDataSource.search(term, tag);
    try {
      return Right(response);
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }
}