import 'package:flutter_application_1/feature/issue/domain/entities/Issue_entity.dart';
import 'package:flutter_application_1/feature/issue/domain/repositort/issue_repository.dart';
import 'package:flutter_application_1/feature/issue/domain/usecases/get_issue_by_Id.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'get_issue.mocks.dart';


@GenerateMocks([IssueRepository])

void main(){
  late MockIssueRepository mockIssueRepository;
  late GetIssueById usecase;
  setUp(() {
    mockIssueRepository = MockIssueRepository();
    usecase = GetIssueById(repository: mockIssueRepository);
  });
  
  final Issue issue = Issue(id: 'issue1', title: "New Issue", description: "This is a new issue", postedDate: '', userName: '');
  const String id = "issue1";
  test ('should get single issue detail', () async {
    when(mockIssueRepository.getIssueById(id)).thenAnswer((_) async => Right(issue));

    final result = await usecase(id);

    expect(result, Right(issue));
    verify(mockIssueRepository.getIssueById(id));
    verifyNoMoreInteractions(mockIssueRepository);
  });
}
