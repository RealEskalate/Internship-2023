import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/edit_user_profile.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_user_test.mocks.dart';

@GenerateMocks([UserRepository])
void main() {
  late EditUserProfile usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = EditUserProfile(mockUserRepository);
  });

  final tUser = UserEntity(
      id: "1",
      username: "testUsername",
      firstName: "testFirstName",
      lastName: "testLastName",
      occupation: "testOccupation",
      selfDescription: "testSelfDescription",
      password: "testPassword",
      image: "testImage");

  test(
      "Should provide the details of the updated user profile to the repository",
      () async {
    when(mockUserRepository.editUserProfile(tUser))
        .thenAnswer((_) async => Right(tUser));
    final result = await usecase(tUser);

    expect(result, Right(tUser));
    verify(mockUserRepository.editUserProfile(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test(
      "Should return a server failure when it fails to update the user profile due to server error",
      () async {
    when(mockUserRepository.editUserProfile(tUser))
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(tUser);
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.editUserProfile(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test(
      "Should return an input failure when it fails to update user profile due to input mismatch",
      () async {
    when(mockUserRepository.editUserProfile(tUser))
        .thenAnswer((_) async => Left(InputFailure("Input Mismatch")));

    final result = await usecase(tUser);
    expect(result, Left(InputFailure("Input Mismatch")));
    verify(mockUserRepository.editUserProfile(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
