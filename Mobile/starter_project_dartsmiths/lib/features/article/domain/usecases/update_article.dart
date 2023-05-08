import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';


class UpdateArticle implements UseCase<Article, Article> {
  final ArticleRepository repository;

  UpdateArticle(this.repository);

  @override
  Future<Either<Failure, Article>> call(Article article) async {

    return await repository.updateArticle(article);
  }
  
}
