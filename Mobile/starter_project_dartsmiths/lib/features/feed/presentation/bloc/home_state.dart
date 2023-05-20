import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';

import 'search_status.dart';

class SearchState {
  final String term;
  final String tag;
  final List<Home> homeData;
  final SearchSubmissionStatus searchSubmissionStatus;

  SearchState({
    this.tag = '',
    this.term = '',
    this.homeData = const [],
    this.searchSubmissionStatus = const InitialSearchStatus(),
  });

  SearchState copyWith({
    String? term,
    String? tag,
    List<Home>? homeData,
    SearchSubmissionStatus? searchSubmissionStatus,
  }) {
    return SearchState(
      tag: tag ?? this.tag,
      term: term ?? this.term,
      homeData: homeData ?? this.homeData,
      searchSubmissionStatus:
          searchSubmissionStatus ?? this.searchSubmissionStatus,
    );
  }
}