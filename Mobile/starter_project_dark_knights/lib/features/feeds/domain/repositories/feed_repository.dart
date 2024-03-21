import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dartz/dartz.dart';

abstract class FeedRepository {
  Future<Either<Failure, List<Article>>> getArticles();
  Future<Either<Failure, List<Article>>> searchArticles(String query);
  Future<Either<Failure, List<Article>>> filterArticles(String tag);
}
