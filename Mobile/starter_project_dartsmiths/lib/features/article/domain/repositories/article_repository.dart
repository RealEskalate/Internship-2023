import 'package:dartz/dartz.dart';
import '../../../../core/error/failures.dart';
import '../entities/article.dart';

abstract class ArticleRepository {
  Future<Either<Failure, Article>> getArticle(Article article);
  // Future<Either<Failure, Article>> getArticle(Article article);
}
