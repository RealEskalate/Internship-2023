import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticleById implements UseCase<Article, Params> {
  final ArticleRepository repository;

  GetArticleById(this.repository);

  @override
  Future<Either<Failure, Article>> call(Params params) async {
    return await repository.getArticleById(params.id);
  }
}

class Params extends Equatable {
  final String id;

  const Params({required this.id});

  @override
  List<Object> get props => [id];
}