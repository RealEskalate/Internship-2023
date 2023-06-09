import 'package:dartsmiths/core/error/exception.dart';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/feed/home/data/datasource/home_remote.dart';
import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';
import 'package:dartsmiths/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';

class HomeRepositoryImpl implements HomeRepository {
  final HomeRemoteDataSource homeRemoteDataSource;
  HomeRepositoryImpl({required this.homeRemoteDataSource});
  @override
  Future<Either<Failure, List<Home>>> search(String term, String tag) async {
    final response = await homeRemoteDataSource.search(term, tag);
    try {
      return Right(response);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}