import 'package:dark_knights/core/errors/exceptions.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_local_data_source.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/data/repositories/user_repository_impl.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'user_repository_impl_test.mocks.dart';

@GenerateMocks([NetworkInfo, UserRemoteDataSource, UserLocalDataSource])
void main() {
  late UserRemoteDataSource mockRemoteDataSource;
  late UserLocalDataSource mockLocalDataSource;
  late NetworkInfo mockNetworkInfo;
  late UserRepositoryImpl repository;
  setUp(
    () {
      mockRemoteDataSource = MockUserRemoteDataSource();
      mockLocalDataSource = MockUserLocalDataSource();
      mockNetworkInfo = MockNetworkInfo();
      repository = UserRepositoryImpl(
          remoteDataSource: mockRemoteDataSource,
          localDataSource: mockLocalDataSource,
          networkInfo: mockNetworkInfo);
    },
  );
  final tUser = UserModel(
      id: "1",
      username: "testUsername",
      firstName: "testFirstName",
      lastName: "testLastName",
      occupation: "testOccupation",
      selfDescription: "testSelfDescription",
      password: "testPassword",
      image: "testImage");

  final tEditedUser = UserModel(
    id: "2",
    username: "testUsername2",
    firstName: "testFirstName2",
    lastName: "testLastName2",
    occupation: "testOccupation2",
    selfDescription: "testSelfDescription2",
    password: "testPassword2",
    image: "testImage2",
  );

  const tUserId = "1";
  final tFollowers = [tUser, tEditedUser];

  group(
    "createUser",
    () {
      test(
        "should create and return a user when the correct data is provided.",
        () async {
          when(mockRemoteDataSource.createUser(tUser))
              .thenAnswer((_) async => tUser);
          final result = await repository.createUser(tUser);
          expect(result, equals(Right(tUser)));
        },
      );

      test(
        "should return a ServerFailure when the user cannot be created",
        () async {
          when(mockRemoteDataSource.createUser(tUser))
              .thenAnswer((_) async => throw ServerException("message"));
          final result = await repository.createUser(tUser);
          expect(
              result, equals(Left(ServerFailure("Internal Server Failure"))));
        },
      );

      test(
        "should return an InputFailure when there is an Input mismatch",
        () async {
          when(mockRemoteDataSource.createUser(tUser)).thenAnswer(
              (_) async => throw InputException("Invalid data provided"));
          final result = await repository.createUser(tUser);
          expect(result, equals(Left(InputFailure("Invalid data provided"))));
        },
      );
    },
  );

  group(
    "editUserProfile",
    () {
      test(
        "should edit the user with the id and return the edited user",
        () async {
          when(mockRemoteDataSource.editUserProfile(tEditedUser))
              .thenAnswer((_) async => tEditedUser);
          final result = await repository.editUserProfile(tEditedUser);
          expect(result, equals(Right(tEditedUser)));
        },
      );

      test(
        "should return a ServerFailure when the user cannot be edited",
        () async {
          when(mockRemoteDataSource.editUserProfile(tEditedUser)).thenAnswer(
              (_) async => throw ServerException("Internal Server Error"));
          final result = await repository.editUserProfile(tEditedUser);
          expect(
              result, equals(Left(ServerFailure("Internal Server Failure"))));
        },
      );

      test(
        "should return an InputFailure when there is an Input mismatch",
        () async {
          when(mockRemoteDataSource.editUserProfile(tEditedUser)).thenAnswer(
              (_) async => throw InputException("Invalid data provided"));
          final result = await repository.editUserProfile(tEditedUser);
          expect(result, equals(Left(InputFailure("Invalid data provided"))));
        },
      );
    },
  );

  group(
    "getFollowers",
    () {
      test(
        "should return all followers of the user with the given id",
        () async {
          when(mockRemoteDataSource.getFollowers(tUserId))
              .thenAnswer((_) async => tFollowers);
          final result = await repository.getFollowers(tUserId);
          expect(result, equals(Right(tFollowers)));
        },
      );

      test(
        "should return ServerFailure when the followers cannot be fetched",
        () async {
          when(mockRemoteDataSource.getFollowers(tUserId)).thenAnswer(
              (_) async => throw ServerException("Internal Server Failure"));
          final result = await repository.getFollowers(tUserId);
          expect(
              result, equals(Left(ServerFailure("Internal Server Failure"))));
        },
      );
    },
  );
}
