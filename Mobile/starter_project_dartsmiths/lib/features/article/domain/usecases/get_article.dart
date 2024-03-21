import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticle implements UseCase<Article, String> {
  final ArticleRepository repository;

  GetArticle(this.repository);

  Future<Either<Failure, Article>> call(id) async {
    return await repository.getArticle(id);
  }
}
