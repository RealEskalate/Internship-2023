import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/article/data/datasources/article_local_data_source.dart';
import 'package:matador/features/article/data/datasources/article_remote_data_source.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class ArticleRepositoryImpl implements ArticleRepository {
  final ArticleRemoteDataSource remoteDataSource;
  final ArticleLocalDataSource localDataSource;

  ArticleRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
  });

  @override
  Future<Either<Failure, Article>> getArticle(String articleId) async {
    try {
      final remoteArticle = await remoteDataSource.getArticle(articleId);
      // Cache the article locally
      await localDataSource.getArticle(articleId);
      return Right(remoteArticle);
    } on Exception {
      try {
        final localArticle = await localDataSource.getArticle(articleId);
        return Right(localArticle);
      } on Exception {
        return Left(CacheFailure());
      }
    }
  }
}