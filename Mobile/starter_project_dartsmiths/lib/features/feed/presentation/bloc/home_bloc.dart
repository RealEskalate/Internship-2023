import 'package:dartsmiths/core/error/exception.dart';
import 'package:dartsmiths/features/feed/home/domain/usecase/home_usecase.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_event.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_state.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/search_status.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../../../../core/error/failures.dart';
import '../../home/domain/entity/home.dart';

class SearchBloc extends Bloc<SearchNewEvent, SearchState> {
  final Search usecase;
  SearchBloc({required this.usecase}) : super(SearchState()) {
    on<SearchTermChanged>((event, emit) {
      emit(state.copyWith(term: event.term));
    });
    on<SearchTagChanged>((event, emit) async {
      emit(state.copyWith(tag: event.tag));
    });
    on<SearchSubmitted>((event, emit) async {
      emit(state.copyWith(
          searchSubmissionStatus: const SearchSubmittingStatus()));
      final response = await usecase(Params(tag: state.tag, term: state.term));
      emit(_successOrFailure(response, state.term, state.tag));
    });
  }
}

SearchState _successOrFailure(
    Either<Failure, List<Home>> data, dynamic term, dynamic tag) {
  return data.fold(
    (failure) => SearchState(
        searchSubmissionStatus:
            SearchSubmissionFailure(exception: ServerException())),
    (success) => SearchState(
        homeData: success,
        searchSubmissionStatus: SearchSubmissionSuccess(homeData: success)),
  );
}
