import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/feeds/domain/repositories/feed_repository.dart';
import 'package:dartz/dartz.dart';

class FilterArticles implements UseCase<List<Article>, String> {
  FeedRepository repository;
  FilterArticles({required this.repository});

  @override
  Future<Either<Failure, List<Article>>> call(String params) async {
    return await repository.filterArticles(params);
  }
}
