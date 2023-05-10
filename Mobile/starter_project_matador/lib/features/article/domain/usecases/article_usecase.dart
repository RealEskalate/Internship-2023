import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class GetArticle implements UseCase<Article,String>{
  
  final ArticleRepository repository;

   GetArticle(this.repository);
   
  @override
  Future<Either<Failure, Article>> call(String articleId) async {
    return await repository.getArticle(articleId);
  } 
}