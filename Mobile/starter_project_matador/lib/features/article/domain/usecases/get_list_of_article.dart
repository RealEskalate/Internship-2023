import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';

class GetArticles implements UseCase<List<Article>, NoParams> {
  final ArticleRepository repository;
  GetArticles(this.repository);

  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getArticles();
  }
}