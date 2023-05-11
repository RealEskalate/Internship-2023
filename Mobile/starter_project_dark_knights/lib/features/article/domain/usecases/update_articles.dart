import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class UpdateArticle {
  final ArticleRepository repository;
  UpdateArticle({required this.repository});

  Future<Either<Failure, Article>> call(String id, Article article) async {
    return await repository.updateArticle(id, article);
  }
}
