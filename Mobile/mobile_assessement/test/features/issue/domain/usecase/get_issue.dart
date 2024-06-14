import 'package:flutter_application_1/core/utils/usecases/usecases.dart';
import 'package:flutter_application_1/feature/issue/domain/entities/Issue_entity.dart';
import 'package:flutter_application_1/feature/issue/domain/repositort/issue_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_application_1/feature/issue/domain/usecases/get_all_issue.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_issue.mocks.dart';

@GenerateMocks([IssueRepository])
void main() {
 

  late MockIssueRepository mockIssueRepository;
  late GetAllIssue usecase;
  setUp(() {
    mockIssueRepository = MockIssueRepository();
    usecase = GetAllIssue(IssueRepository as IssueRepository);
  });
  
  final List<Issue> issues = [
    Issue(id: 'issue1', title: "Issue 1", description: "This is issue 1", postedDate: '', userName: ''),
    Issue(id: 'issue2', title: "Issue 2", description: "This is issue 2", postedDate: '', userName: ''),
    Issue(id: 'issue3', title: "Issue 3", description: "This is issue 3", postedDate: '', userName: ''),
  ];
  
  test('should get all issues', () async {
    when(mockIssueRepository.getIssue()).thenAnswer((_) async => Right(issues));

    final result = await usecase(IssueRepository as NoParams);

    expect(result, Right(issues));
// //     verify(mockIssueRepository.getIssues());
    verifyNoMoreInteractions(mockIssueRepository);
  });
}