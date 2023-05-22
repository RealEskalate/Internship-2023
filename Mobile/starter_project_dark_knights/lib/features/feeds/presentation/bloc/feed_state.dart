part of 'feed_bloc.dart';

abstract class FeedState extends Equatable {
  const FeedState();

  @override
  List<Object> get props => [];
}

class FeedLoading extends FeedState {}

class FeedLoaded extends FeedState {
  final List<Article> articles;

  const FeedLoaded({required this.articles});

  @override
  List<Object> get props => [articles];
}

class ArticleLoaded extends FeedState {
  final Article article;

  const ArticleLoaded({required this.article});

  @override
  List<Object> get props => [article];
}

class FeedError extends FeedState {
  final Failure failure;

  const FeedError({required this.failure});

  @override
  List<Object> get props => [failure];
}
