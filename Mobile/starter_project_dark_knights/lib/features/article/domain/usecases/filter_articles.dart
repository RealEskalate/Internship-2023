import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class FilterArticle {
  final ArticleRepository repository;
  FilterArticle({required this.repository});

  Future<Either<Failure, List<Article>>> call(Params params) async {
    return await repository.filterArticles(params.filters);
  }
}

class Params extends Equatable{
  final List filters;
  const Params({required this.filters});

  @override
  List<Object> get props => [filters];
}