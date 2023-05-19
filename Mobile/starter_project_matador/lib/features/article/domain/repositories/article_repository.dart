import '../entities/article.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/error/failures.dart';

abstract class ArticleRepository {
  Future<Either<Failure,Article>> getArticleById(String articleId);
  Future<Either<Failure, List<Article>>> getArticles();
}