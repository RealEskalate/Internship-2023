import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/feeds/data/datasources/feed_remote_data_source.dart';
import 'package:dark_knights/features/feeds/domain/repositories/feed_repository.dart';
import 'package:dartz/dartz.dart';

class FeedRepositoryImplementation implements FeedRepository {
  final FeedRemoteDataSource remoteDataSource;

  FeedRepositoryImplementation({
    required this.remoteDataSource,
  });

  @override
  Future<Either<Failure, List<Article>>> getArticles() async {
    try {
      final remoteArticles = await remoteDataSource.getArticles();
      return Right(remoteArticles);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure!"));
    }
  }

  @override
  Future<Either<Failure, List<Article>>> filterArticles(String tag) async {
    try {
      final remoteArticles = await remoteDataSource.filterArticles(tag);
      return Right(remoteArticles);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure!"));
    }
  }

  @override
  Future<Either<Failure, List<Article>>> searchArticles(String query) async {
    try {
      final remoteArticles = await remoteDataSource.searchArticles(query);
      return Right(remoteArticles);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure!"));
    }
  }
}
