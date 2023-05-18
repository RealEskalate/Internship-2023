part of 'article_bloc.dart';

abstract class ArticleState extends Equatable {
  const ArticleState();

  @override
  List<Object?> get props => [];
}

class ArticleInitialState extends ArticleState {}

class ArticleLoadingState extends ArticleState {}

class ArticleSuccessState extends ArticleState {
  final Article article;

  const ArticleSuccessState({required this.article});

  @override
  List<Object?> get props => [article];
}

class ArticlesSuccessState extends ArticleState {
  final List<Article> articles;

  const ArticlesSuccessState({required this.articles});

  @override
  List<Object?> get props => [articles];
}

class ArticleFailureState extends ArticleState {
  final Failure error;

  const ArticleFailureState({required this.error});
  @override
  List<Object?> get props => [error];
}
