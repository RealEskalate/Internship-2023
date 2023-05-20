abstract class SearchNewEvent {}

class SearchTermChanged extends SearchNewEvent {
  final String term;
  SearchTermChanged({required this.term});
}

class SearchTagChanged extends SearchNewEvent {
  final String tag;
  SearchTagChanged({required this.tag});
}

class SearchSubmitted extends SearchNewEvent {}
