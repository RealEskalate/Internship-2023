import 'package:dartz/dartz.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Either<Failure, List<Article>>> getArticles();
  Future<Either<Failure, Article>> getArticleById(String id);
  Future<Either<Failure, List<Article>>> getArticlesByUserId(String userId);
  Future<Either<Failure, Article>> postArticle(Article article);
  Future<Either<Failure, Article>> updateArticle(String id, Article article);
  Future<Either<Failure, Article>> deleteArticle(String id);
}