import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import '../entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class GetArticle {
  final ArticleRepository repository;

   GetArticle(this.repository);

  Future<Either<Failure, Article>> call(String articleId) async {
    return await repository.getArticle(articleId);
  } 
}