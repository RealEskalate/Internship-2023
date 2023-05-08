import 'package:dartz/dartz.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class GetArticles implements UseCase<Article, NoParams> {
  final ArticleRepository repository;

  GetArticles(this.repository);

  @override
  Future<Either<Failure, Article>> call(NoParams params) async {
    return await repository.getArticles();
  }
}
