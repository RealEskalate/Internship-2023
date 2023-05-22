part of 'feed_bloc.dart';

@immutable
abstract class FeedEvent extends Equatable {
  const FeedEvent() : super();

  @override
  List<Object?> get props => [];
}

class GetAllArticlesEvent extends FeedEvent{
}