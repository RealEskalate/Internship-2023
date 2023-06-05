import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';
import 'package:mobile_assessement/core/usecases/usecase.dart';

import '../../domain/usecases/getallinfo.dart';
import '../../domain/usecases/info.dart';

part 'issues_event.dart';
part 'issues_state.dart';

class IssueBloc extends Bloc<IssueBlocEvent, IssueBlocState> {
  GetAllInfoDetail getAllInfoDetail;
  GetInfoDetail getInfoDetail;

  IssueBloc(this.getAllInfoDetail, this.getInfoDetail)
      : super(IssueBlocInitial()) {
        
    on<LoadAllIssueEvent>(_issues);
    on<LoadIssueEvent>(_issueById);
  }

  void _issueById(LoadIssueEvent event, Emitter emit)async{
     emit(IssueLoading());

    final failureOrDetail = await getInfoDetail(Params(id: event.id));

    emit(_detailOrFailure(failureOrDetail));
  }


  void _issues(LoadAllIssueEvent event, Emitter emit) async {
    emit(IssueLoading());

    final failureOrDetail = await getAllInfoDetail(NoParams());

    emit(_detailOrFailure(failureOrDetail));
  }

  _detailOrFailure(both) {
    return both.fold(
      (failure) => IssueFailureState(),
      (detail, alldetail) => IssueLoaded(detail, alldetail),
    );
  }
}
