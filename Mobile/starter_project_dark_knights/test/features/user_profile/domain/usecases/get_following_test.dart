import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_all_users.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_following.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

void main() {
  late GetFollowing usecase;
  late MockUserRepository mockUserRepository;

  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetFollowing(mockUserRepository);
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
  const userId = "1";
  test("Should return all users that the current user follows", () async {
    when(mockUserRepository.getFollowing(userId))
        .thenAnswer((_) async => Right(tUsers));
    final result = await usecase(userId);

    expect(result, Right(tUsers));
    verify(mockUserRepository.getFollowing(userId));
    verifyNoMoreInteractions(mockUserRepository);
  });

  test(
      "Should return server failure when failed to get all users that the current user follows.",
      () async {
    when(mockUserRepository.getFollowing(userId))
        .thenAnswer((_) async => Left(ServerFailure("Internal Server Error")));

    final result = await usecase(userId);
    expect(result, Left(ServerFailure("Internal Server Error")));
    verify(mockUserRepository.getFollowing(userId));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
