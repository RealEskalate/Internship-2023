import 'package:equatable/equatable.dart';
import 'package:matador/features/article/domain/entities/article.dart';

abstract class ArticleState extends Equatable {
  const ArticleState();
}

class ArticleInitialState extends ArticleState {
  @override
  List<Object> get props => [];
}

class ArticleLoadingState extends ArticleState {
  @override
  List<Object> get props => [];
}

class ArticleSuccessState extends ArticleState {
  final Article article;

  ArticleSuccessState({required this.article});

  @override
  List<Object> get props => [article];
}

class ArticleFailureState extends ArticleState {
  final String error;

  ArticleFailureState({required this.error});

  @override
  List<Object> get props => [error];
}