import 'package:dartz/dartz.dart';
import 'package:matador/core/error/exception.dart';
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
  Future<Either<Failure, Article>> getArticleById(String articleId) async {
    try {
      final remoteArticle = await remoteDataSource.getArticleById(articleId);
      // Cache the article locally

      return Right(remoteArticle);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, List<Article>>> getArticles() async {
    try {
      final remoteArticles = await remoteDataSource.getArticles();
      // Cache the articles locally

      return Right(remoteArticles);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}


