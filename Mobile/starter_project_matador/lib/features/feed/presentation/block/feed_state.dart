part of 'feed_bloc.dart';

@immutable
abstract class FeedState extends Equatable {
  const FeedState();

  @override
  List<Object?> get props => [];
}

class InitialFeedState extends FeedState {}

class LoadingFeedState extends FeedState {}

class LoadedFeedState extends FeedState {
  final List<Article> articles;

  const LoadedFeedState({required this.articles});

  @override
  List<Object?> get props => [articles];
}

class ErrorFeedState extends FeedState {
  final String message;

  const ErrorFeedState({required this.message});

  @override
  List<Object?> get props => [message];
}
