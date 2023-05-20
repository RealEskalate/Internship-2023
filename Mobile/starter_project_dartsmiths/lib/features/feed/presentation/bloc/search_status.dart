import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';

abstract class SearchSubmissionStatus {
  const SearchSubmissionStatus();
}

class InitialSearchStatus extends SearchSubmissionStatus {
  const InitialSearchStatus();
}

class SearchSubmittingStatus extends SearchSubmissionStatus {
  const SearchSubmittingStatus();
}

class SearchSubmissionSuccess extends SearchSubmissionStatus {
  final List<Home> homeData;
  const SearchSubmissionSuccess({required this.homeData});
}

class SearchSubmissionFailure extends SearchSubmissionStatus {
  Exception exception;
  SearchSubmissionFailure({required this.exception});
}
