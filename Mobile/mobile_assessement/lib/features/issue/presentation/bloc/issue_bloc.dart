import 'package:bloc/bloc.dart';
import '../../domain/repositories/issue_repository.dart';
import 'issue_event.dart';
import 'issue_state.dart';

class IssueBloc extends Bloc<IssueEvent, IssueState> {
  final IssueRepository repository;

  IssueBloc(this.repository);

  @override
  IssueState get initialState => IssueInitial();

  @override
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