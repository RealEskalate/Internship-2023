import 'package:mobile_assessement/features/issue/domain/entities/issue.dart';
import 'package:mobile_assessement/features/issue/domain/repositories/issue_repository.dart';
import 'package:mobile_assessement/features/issue/domain/usecases/get_issue.dart';
import 'package:test/test.dart';
import 'package:mockito/mockito.dart';


class MockIssueRepository extends Mock implements IssueRepository {}

void main() {
  late GetIssue useCase;
  late MockIssueRepository mockRepository;

  setUp(() {
    mockRepository = MockIssueRepository();
    useCase = GetIssue(mockRepository);
  });

  test('should return an issue from the repository', () async {
    // Arrange
    final expectedIssue = Issue(title: 'Example Issue',description: 'example desc', name: 'abebe');
    when(mockRepository.getIssue()).thenAnswer((_) async => expectedIssue);

    // Act
    final result = await useCase.execute();

    // Assert
    expect(result, equals(expectedIssue));
    verify(mockRepository.getIssue()).called(1);
    verifyNoMoreInteractions(mockRepository);
  });
}
