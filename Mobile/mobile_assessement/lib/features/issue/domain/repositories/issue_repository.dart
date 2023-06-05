
import '../entities/issue.dart';

abstract class IssueRepository {
  Future<Issue> getIssue();
}
