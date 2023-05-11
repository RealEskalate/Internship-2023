import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/create_user.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/delete_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

@GenerateMocks([UserRepository])
void main() {
  late CreateUser usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = CreateUser(mockUserRepository);
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

  test("Should Create the user with the given data and return the created user",
      () async {
    when(mockUserRepository.createUser(tUser))
        .thenAnswer((_) async => Right(tUser));

    final result = await usecase(tUser);
    expect(result, Right(tUser));
    verify(mockUserRepository.createUser(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test("Should return Server failure when user is not create", () async {
    when(mockUserRepository.createUser(tUser))
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(tUser);
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.createUser(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test(
      "Should return an input failure when it fails to create user profile due to input mismatch",
      () async {
    when(mockUserRepository.createUser(tUser))
        .thenAnswer((_) async => Left(InputFailure("Input Mismatch")));

    final result = await usecase(tUser);
    expect(result, Left(InputFailure("Input Mismatch")));
    verify(mockUserRepository.createUser(tUser));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
