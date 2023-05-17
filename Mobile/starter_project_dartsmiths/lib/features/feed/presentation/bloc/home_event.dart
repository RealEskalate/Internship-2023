part of 'home_bloc.dart';

abstract class HomeEvent extends Equatable {
  const HomeEvent();

  @override
  List<Object> get props => [];
}

class SearchEvent extends HomeEvent {
  final String term;
  final String tag;
  const SearchEvent({required this.term, required this.tag});
  
  @override
  List<Object> get props => [term, tag];
  
}
