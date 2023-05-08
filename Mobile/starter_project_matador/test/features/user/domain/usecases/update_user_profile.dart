import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';
import 'package:matador/features/user/domain/usecases/update_user_profile.dart';
import 'package:mockito/mockito.dart';

class MockUserRepository extends Mock implements UserRepository {}

void main() {
  late UpdateUserProfile updateUserProfile;
  late MockUserRepository mockRepository;

  setUp(() {
    mockRepository = MockUserRepository();
    updateUserProfile = UpdateUserProfile(mockRepository);
  });

  group('UpdateUserProfile', () {
    const int userId = 1;
    const String newUserName = 'john_doe';
    const String newEmail = 'john.doe@example.com';
    const String newFullName = 'John Doe';

    test('should update user profile successfully', () async {

      const updatedUser = User(
        id: userId,
        userName: newUserName,
        email: newEmail,
        fullName: newFullName,
      );
      when(mockRepository.updateUserProfile(updatedUser))
          .thenAnswer((_) async => const Right(updatedUser));

      final result = await updateUserProfile.execute(
        id: userId,
        userName: newUserName,
        email: newEmail,
        fullName: newFullName,
      );

      expect(result, equals(const Right(updatedUser)));
      verify(mockRepository.updateUserProfile(updatedUser)).called(1);
      verifyNoMoreInteractions(mockRepository);
    });

  });
}
