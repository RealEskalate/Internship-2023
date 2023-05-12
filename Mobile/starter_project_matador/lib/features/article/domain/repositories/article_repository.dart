import '../entities/article.dart';
import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';

abstract class ArticleRepository {
  Future<Either<Failure,Article>> getArticle(String articleId);
  Future<Either<Failure, Article>> updateArticle(Article article);
  Future<Either<Failure, Article>> deleteArticle(String articleId);
  Future<Either<Failure, Article>> postArticle(Article article);
}