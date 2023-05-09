import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticle implements UseCase<Article, Params> {
  final ArticleRepository repository;

  GetArticle(this.repository);

  Future<Either<Failure, Article>> call(Params params) async {
    return await repository.getArticle(params.id);
  }
}

class Params {
  String id;
  Params({required this.id});
}
