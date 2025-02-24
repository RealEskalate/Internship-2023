import 'package:bloc/bloc.dart';
import '../../domain/repositories/issue_repository.dart';
import '../../domain/entities/issue.dart';

import 'issue_event.dart';
import 'issue_state.dart';

class IssueBloc extends Bloc<IssueEvent, IssueState> {
  final IssueRepository repository;

  IssueBloc(this.repository);

  IssueState get initialState => IssueInitial();

  Stream<IssueState> mapEventToState(IssueEvent event) async* {
    if (event is IssueRequested) {
      yield IssueLoading();

      try {
        final issue = await repository.getIssue();
        yield IssueLoaded(issue);
      } catch (e) {
        yield IssueError(e);
      }
    }
  }
}
