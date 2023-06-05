import 'package:flutter_application_1/feature/issue/domain/usecases/get_issue_by_Id.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../../domain/repositort/issue_repository.dart';
import '../../domain/usecases/get_all_issue.dart';
import 'issue_event.dart';
import 'issue_state.dart';

class IssueBloc extends Bloc<IssueEvent, IssueState> {
  final IssueRepository issueRepository;
  final GetAllIssue getAllIssue;
  final GetIssueById getIssueById;

  IssueBloc({
    required this.issueRepository,
    required this.getAllIssue,
    required this.getIssueById, 
  }) : super(IssueInitial());

  @override
  Stream<IssueState> mapEventToState(IssueEvent event) async* {
    if (event is GetAllIssuesEvent) {
      try {
        yield IssueLoadingState();
        final eitherIssues = await issueRepository.getIssue();
        yield eitherIssues.fold(
          (failure) => IssueErrorState(failure.toString()),
          (issues) => IssueSuccessState(issue: issues),
        );
      } catch (e) {
        yield IssueErrorState(e.toString());
      }
    } else if (event is GetIssueByIdEvent) {
      try {
        yield IssueLoadingState();
        final eitherIssue = await getIssueById(event.id);
        yield eitherIssue.fold(
          (failure) => IssueErrorState(failure.toString()),
          (issue) => IssueSuccessState(issue: [issue]),
        );
      } catch (e) {
        yield IssueErrorState(e.toString());
      }
    } else {
      yield IssueErrorState("Unknown event: $event");
    }
  }
}