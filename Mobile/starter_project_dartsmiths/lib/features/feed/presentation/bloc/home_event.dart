part of 'home_bloc.dart';

abstract class HomeEvent extends Equatable {
  final String term;
  final String tag;

  const HomeEvent(this.term, this.tag);
  

  @override
  List<Object> get props => [];
}

class SearchEvent extends HomeEvent {
  const SearchEvent(super.term, super.tag);

  @override
  List<Object> get props => [term, tag];
}
