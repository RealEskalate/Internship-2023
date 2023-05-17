import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dartz/dartz.dart';

import '../../../../core/errors/exception.dart';
import '../../domain/repositories/article_repository.dart';
import '../datasources/article_local_data_source.dart';
import '../datasources/article_remote_data_source.dart';

class ArticleRepositoryImpl implements ArticleRepository {
  final ArticleRemoteDataSource remoteDataSource;
  final ArticleLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  ArticleRepositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
    required this.networkInfo,
  });
  @override
  Future<Either<Failure, List<Article>>> getArticles() async {
    if (await networkInfo.isConnected) {
      try {
        final remoteArticles = await remoteDataSource.getArticles();
        localDataSource.cacheArticles(remoteArticles);
        return Right(remoteArticles);
      } on ServerException {
        return Left(ServerFailure("Internal Server Failure!"));
      }
    } else {
      try {
        final localArticles = await localDataSource.getLastArticles();
        return Right(localArticles);
      } on CacheException {
        return Left(CacheFailure("Local Catch Sever Failure"));
      }
    }
  }

  @override
  Future<Either<Failure, Article>> deleteArticle(String id) async {
    try {
      final deletedArticle = await remoteDataSource.deleteArticle(id);
      return Right(deletedArticle);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure!"));
    }
  }

  @override
  Future<Either<Failure, Article>> getArticleById(String id) async {
    try {
      final article = await remoteDataSource.getArticleById(id);
      return Right(article);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure"));
    }
  }

  @override
  Future<Either<Failure, List<Article>>> getArticlesByUserId(
      String userId) async {
    try {
      final articlesByUser = await remoteDataSource.getArticlesByUserId(userId);
      return Right(articlesByUser);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure"));
    }
  }

  @override
  Future<Either<Failure, Article>> postArticle(Article article) async {
    try {
      final createdArticle = await remoteDataSource.postArticle(article);
      return Right(createdArticle);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure"));
    }
  }

  @override
  Future<Either<Failure, Article>> updateArticle(
      String id, Article article) async {
    try {
      final updatedArticle = await remoteDataSource.updateArticle(id, article);
      return Right(updatedArticle);
    } on ServerException {
      return Left(ServerFailure("Internal Server Failure"));
    }
  }
}
