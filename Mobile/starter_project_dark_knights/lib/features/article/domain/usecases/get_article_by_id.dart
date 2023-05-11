import 'package:dark_knights/features/article/domain/usecases/delete_article.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticleById {
  final ArticleRepository repository;
  GetArticleById({required this.repository});

  Future<Either<Failure, Article>> call(String id) async {
    return await repository.getArticleById(id);
  }
}
