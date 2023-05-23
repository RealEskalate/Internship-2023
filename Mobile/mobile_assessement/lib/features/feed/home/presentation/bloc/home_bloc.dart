// import 'package:mobile_assessement/core/error/exception.dart';
// import 'package:mobile_assessement/features/feed/home/domain/usecase/home_usecase.dart';

// import 'package:dartz/dartz.dart';
// import 'package:flutter_bloc/flutter_bloc.dart';


// class SearchBloc extends Bloc<SearchNewEvent, SearchState> {
//   final Search usecase;
//   SearchBloc({required this.usecase}) : super(SearchState()) {
//     on<SearchCityChanged>((event, emit) {
//       emit(state.copyWith(term: event.city));
//     });
//     on<SearchTagChanged>((event, emit) async {
//       emit(state.copyWith(tag: event.tag));
//     });
//     on<SearchSubmitted>((event, emit) async {
//       emit(state.copyWith(
//           searchSubmissionStatus: const SearchSubmittingStatus()));
//       final response = await usecase(Params(city: state.city));
//       emit(_successOrFailure(response, state.city));
//     });
//   }
// }

// SearchState _successOrFailure(
//     Either<Failure, Home> data, dynamic city) {
//   return data.fold(
//     (failure) => SearchState(
//         searchSubmissionStatus:
//             SearchSubmissionFailure(exception: ServerException())),
//     (success) => SearchState(
//         homeData: success,
//         searchSubmissionStatus: SearchSubmissionSuccess(homeData: success)),
//   );
// }