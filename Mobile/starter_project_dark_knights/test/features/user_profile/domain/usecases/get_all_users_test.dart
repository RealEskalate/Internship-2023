import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_all_users.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_number_of_followers.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

void main() {
  late GetAllUsers usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetAllUsers(mockUserRepository);
  });

  final tUser1 = UserEntity(
      id: "1",
      username: "testUsername",
      firstName: "testFirstName",
      lastName: "testLastName",
      occupation: "testOccupation",
      selfDescription: "testSelfDescription",
      password: "testPassword",
      image: "testImage");

  final tUser2 = UserEntity(
      id: "2",
      username: "testUsername2",
      firstName: "testFirstName2",
      lastName: "testLastName2",
      occupation: "testOccupation2",
      selfDescription: "testSelfDescription2",
      password: "testPassword2",
      image: "testImage2");

  List<UserEntity> tUsers = [tUser1, tUser2];

  test("Should return all users", () async {
    when(mockUserRepository.getAllUsers())
        .thenAnswer((_) async => Right(tUsers));
    final result = await usecase(NoParams());

    expect(result, Right(tUsers));
    verify(mockUserRepository.getAllUsers());
    verifyNoMoreInteractions(mockUserRepository);
  });

  test("Should return server failure when failed to get all users.", () async {
    when(mockUserRepository.getAllUsers())
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(NoParams());
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.getAllUsers());
    verifyNoMoreInteractions(mockUserRepository);
  });
}
