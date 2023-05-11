import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class DeleteArticle {
  final ArticleRepository repository;
  DeleteArticle({required this.repository});

  Future<Either<Failure, Article>> call (Params params) async {
    return await repository.deleteArticle(params.id);
  }
}

class Params extends Equatable{
  final String id;
  const Params({required this.id});

  @override
  List<Object> get props => [id];
}