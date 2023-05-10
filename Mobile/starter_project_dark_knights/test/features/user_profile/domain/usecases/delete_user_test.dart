import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/delete_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

void main() {
  late DeleteUser usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = DeleteUser(mockUserRepository);
  });

  const String tId = "1";
  final tDeletedUser = UserEntity(
      id: tId,
      username: "testUsername",
      firstName: "testFirstName",
      lastName: "testLastName",
      occupation: "testOccupation",
      selfDescription: "testSelfDescription",
      password: "testPassword",
      image: "testImage");

  test("Should Delete the user with the given id and return the deleted user",
      () async {
    when(mockUserRepository.deleteUser(tId))
        .thenAnswer((_) async => Right(tDeletedUser));

    final result = await usecase(tId);
    expect(result, Right(tDeletedUser));
    verify(mockUserRepository.deleteUser(tId));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test("Should return Server failure when user is not deleted", () async {
    when(mockUserRepository.deleteUser(tId))
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(tId);
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.deleteUser(tId));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
