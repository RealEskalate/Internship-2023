import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Either<Failure, List<Article>>> getArticles();
  Future<Either<Failure, Article>> getArticleById(String id);
  Future<Either<Failure, Article>> getArticlesByUserId(String userId);
  Future<Either<Failure, List<Article>>> searchArticles(String keyword);
  Future<Either<Failure, List<Article>>> filterArticles(List filters);
  Future<Either<Failure, Article>> postArticle(Article article);
  Future<Either<Failure, Article>> updateArticle(String id, Article article);
  Future<Either<Failure, Article>> deleteArticle(String);
}