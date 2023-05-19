import 'package:bloc/bloc.dart';
import 'package:dartsmiths/core/failure_message/failure_message.dart';
import 'package:dartsmiths/features/feed/home/domain/usecase/home_usecase.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import '../../../../core/error/failures.dart';
import '../../home/domain/entity/home.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final Search usecase;
  HomeBloc({required this.usecase}) : super(InitialState()) {
    on<SearchEvent>(_searchBlog);
  }
  void _searchBlog(HomeEvent event, Emitter<HomeState> emit) async {
    emit(LoadingState());
    final result = await usecase(Params(tag: event.tag, term: event.term));
    emit(_successOrFailure(result));
  }

//Should be list of blogs
  HomeState _successOrFailure(Either<Failure, List<Home>> data) {
    return data.fold(
      (failure) => const FailureState(message: failureMessage),
      (success) => SuccessState(homeData: success),
    );
  }
}
