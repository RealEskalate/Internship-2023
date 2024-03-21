import 'package:dartsmiths/core/error/exception.dart';
import 'package:dartsmiths/core/network/network_info.dart';
import 'package:dartsmiths/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dartsmiths/features/article/data/models/article_model.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartsmiths/features/article/domain/usecases/get_article.dart';
import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';

import 'package:dartsmiths/core/error/failures.dart';


class ArticleRepositoryImpl implements ArticleRepository {
  final ArticleRemoteDataSource articleRemoteDataSource;
  final NetworkInfo networkInfo;

  ArticleRepositoryImpl(
      {required this.articleRemoteDataSource, required this.networkInfo});

  @override
  Future<Either<Failure, Article>> getArticle(String id) async {
    final networkStatus = await networkInfo.isConnected;
    try {
      if (!networkStatus){
        return Left(ServerFailure());
      }
      final article = await articleRemoteDataSource.GetArticle(id);
      return Right(article);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Article>> postArticle(Article article) async {
    final networkStatus = await networkInfo.isConnected;
    try {
      if (!networkStatus){
        return Left(ServerFailure());
      }
      ArticleModel articleModel = ArticleModel(
          id: article.id,
          title: article.title,
          subTitle: article.subTitle,
          content: article.content,
          tags: article.tags,
          authorId: article.authorId);
      final responseArticle =
          await articleRemoteDataSource.postArticle(articleModel);
      return Right(responseArticle);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Article>> updateArticle(Article article) async {
    try {
      final networkStatus = await networkInfo.isConnected;
      if (!networkStatus){
        return Left(ServerFailure());
      }
      ArticleModel articleModel = ArticleModel(
          id: article.id,
          title: article.title,
          subTitle: article.subTitle,
          content: article.content,
          tags: article.tags,
          authorId: article.authorId);
      final responseArticle =
          await articleRemoteDataSource.updateArticle(articleModel);
      return Right(responseArticle);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

}
