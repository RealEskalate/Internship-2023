import '../entities/issue.dart';
import '../repositories/issue_repository.dart';

class GetIssue {
  final IssueRepository repository;

  GetIssue(this.repository);

  Future<Issue> execute() {
    return repository.getIssue();
  }
}
