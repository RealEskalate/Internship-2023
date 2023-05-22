part of 'feed_bloc.dart';

abstract class FeedEvent extends Equatable {
  const FeedEvent();

  @override
  List<Object> get props => [];
}

class FetchArticles extends FeedEvent {}

class SearchArticlesEvent extends FeedEvent {
  final String query;

  const SearchArticlesEvent({required this.query});

  @override
  List<Object> get props => [query];
}

class FilterArticlesEvent extends FeedEvent {
  final String category;

  const FilterArticlesEvent({required this.category});

  @override
  List<Object> get props => [category];
}

class LoadArticleEvent extends FeedEvent {
  final String id;

  const LoadArticleEvent({required this.id});

  @override
  List<Object> get props => [id];
}
