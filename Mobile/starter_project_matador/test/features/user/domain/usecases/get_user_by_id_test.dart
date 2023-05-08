import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';
import 'package:matador/features/user/domain/usecases/get_user_by_id.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'get_user_by_id_test.mocks.dart';

@GenerateMocks([UserRepository])
void main() {

  GetUserById? usecase;
  MockUserRepository? mockUserRepository;

  setUp(() {
  mockUserRepository = MockUserRepository();
  usecase = GetUserById(mockUserRepository);
  });

  final tId = 1;
  final tUser = User(
      id: tId,
      userName: "test",
      email: "test@email.com",
      fullName: "Test Tester");

  test("should get user for the id from the user repository", () async {
    when(mockUserRepository!.getUserById(tId))
        .thenAnswer((realInvocation) async => Right(tUser));

    final result = await usecase!.execute(id: tId);
    // UseCase should simply return whatever was returned from the Repository
    expect(result, Right(tUser));
    // Verify that the method has been called on the Repository
    verify(mockUserRepository!.getUserById(tId));
    // Only the above method should be called and nothing more.
    verifyNoMoreInteractions(mockUserRepository);
  });
}
