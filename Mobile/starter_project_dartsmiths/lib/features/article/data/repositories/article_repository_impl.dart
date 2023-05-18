import 'package:dartsmiths/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dartsmiths/features/article/data/models/article_model.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartsmiths/features/article/domain/usecases/get_article.dart';
import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';

import 'package:dartsmiths/core/error/failures.dart';

import '../../../../platform/network_info.dart';

class ArticleRepositoryImpl implements ArticleRepository {
  final ArticleRemoteDataSource articleRemoteDataSource;
  final NetworkInfo networkInfo;

  ArticleRepositoryImpl(
      {required this.articleRemoteDataSource, required this.networkInfo});

  @override
  Future<Either<Failure, Article>> getArticle(String id) async {
    networkInfo.isConnected;
    try {
      final article = await articleRemoteDataSource.GetArticle(id);
      return Right(article);
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Article>> postArticle(Article article) async {
    try {
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
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, Article>> updateArticle(Article article) async {
    try {
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
    } on ServerFailure {
      return Left(ServerFailure());
    }
  }

  // @override
  // Future<Either<Failure, Article>> GetArticle(int number) {
  //   networkInfo.isConnected;
  //   return null;
  // }
}
