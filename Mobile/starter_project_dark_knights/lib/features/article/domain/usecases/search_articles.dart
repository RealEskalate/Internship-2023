import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/article.dart';
import '../repositories/article_repository.dart';

class SearchArticle {
  final ArticleRepository repository;
  SearchArticle({required this.repository});

  Future<Either<Failure, List<Article>>> call(Params params) async {
    return await repository.searchArticles(params.keyword);
  }
}

class Params extends Equatable{
  final String keyword;
  const Params({required this.keyword});

  @override
  List<Object> get props => [keyword];
}