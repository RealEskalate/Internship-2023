import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class DeleteArticle {
  final ArticleRepository repository;
  DeleteArticle({required this.repository});

  Future<Either<Failure, Article>> call (String id) async {
    return await repository.deleteArticle(id);
  }
}
