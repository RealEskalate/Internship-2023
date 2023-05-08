import 'package:dark_knights/core/error/failures.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dartz/dartz.dart';

abstract class ArticleRepository {
  Future<Either<Failure, Article>> getArticles();
  Future<Either<Failure, Article>> getArticleById(String id);
  Future<Either<Failure, Article>> getArticlesByUserId(String userId);
  Future<Either<Failure, Article>> searchArticles(String keyword);
  Future<Either<Failure, Article>> filterArticles(filters);
  Future<Either<Failure, Article>> postArticle(Article article);
  Future<Either<Failure, Article>> updateArticle(String id, Article article);
  Future<Either<Failure, Article>> deleteArticle();
}
