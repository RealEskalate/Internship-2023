import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class UpdateArticle {
  final ArticleRepository repository;
  UpdateArticle({required this.repository});

  Future<Either<Failure, Article>> call(Params params) async {
    return await repository.updateArticle(params.id, params.article);
  }
}

class Params extends Equatable{
  final String id;
  final Article article;
  const Params({required this.id, required this.article});

  @override
  List<Object> get props => [article];
}