import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class PostArticle {
  final ArticleRepository repository;
  PostArticle({required this.repository});

  Future<Either<Failure, Article>> call(Article article) async {
    return await repository.postArticle(article);
  }
}
