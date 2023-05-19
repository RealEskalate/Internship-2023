import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class GetArticleById implements UseCase<Article,String>{
  
  final ArticleRepository repository;
   GetArticleById(this.repository);
   
  @override
  Future<Either<Failure, Article>> call(String articleId) async {
    return await repository.getArticleById(articleId);
  }


}