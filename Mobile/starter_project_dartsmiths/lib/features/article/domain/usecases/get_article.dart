import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

class GetArticle implements UseCase<Article, Params> {
  final ArticleRepository repository;

  GetArticle(this.repository);

  @override
  Future call(Params params) async {
    return await repository.getArticle();
  }
}

class Params extends Equatable {
  final int number;

  Params({required this.number});

  @override
  List<Object> get props => [number];
}
