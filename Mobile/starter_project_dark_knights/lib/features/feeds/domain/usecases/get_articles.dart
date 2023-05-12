import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/feeds/domain/repositories/feed_repository.dart';
import 'package:dartz/dartz.dart';

class GetArticles implements UseCase<List<Article>, NoParams> {

  FeedRepository repository;
  GetArticles({required this.repository});
  
  @override
  Future<Either<Failure, List<Article>>> call(NoParams params) async {
    return await repository.getArticles();
  }
}
