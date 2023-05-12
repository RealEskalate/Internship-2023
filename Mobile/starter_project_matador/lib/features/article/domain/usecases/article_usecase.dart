import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class GetArticle implements UseCase<Article,String>{
  
  final ArticleRepository repository;

   GetArticle(this.repository);
   
  @override
  Future<Either<Failure, Article>> call(String articleId) async {
    return await repository.getArticle(articleId);
  } 
}

class UpdateArticle implements UseCase<Article, Article> {
  final ArticleRepository repository;

  UpdateArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(Article article) async {
    return await repository.updateArticle(article);
  }
}

class DeleteArticle implements UseCase<Article, String> {
  final ArticleRepository repository;

  DeleteArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(String articleId) async {
    return await repository.deleteArticle(articleId);
  }
}

class PostArticle implements UseCase<Article, Article> {
  final ArticleRepository repository;

  PostArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(Article article) async {
    return await repository.postArticle(article);
  }
}