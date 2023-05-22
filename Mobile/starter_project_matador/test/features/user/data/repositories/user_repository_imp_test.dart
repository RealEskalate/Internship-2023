import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/user/data/datasources/user_remote_data_source.dart';
import 'package:matador/features/user/data/models/user_model.dart';
import 'package:matador/features/user/data/repositories/user_repository_imp.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'user_repository_imp_test.mocks.dart';

@GenerateMocks([UserRemoteDataSource])
void main() {
  UserRepositoryImpl? repository;
  MockUserRemoteDataSource? mockRemoteDataSource;

  setUp(() {
    mockRemoteDataSource = MockUserRemoteDataSource();
    repository = UserRepositoryImpl(
      remoteDataSource: mockRemoteDataSource!,
    );
  });

  group('addUser', () {
    final tUser = UserModel(
        id: '1',
        userName: 'testuser',
        email: 'testuser@example.com',
        fullName: 'Test User',
        expertise: 'Test Expertise',
        aboutMe: 'Test about me',
        followersCount: 10,
        followingCount: 20,
        profilePicture: 'http://example.com/profile.png');

    test('should add user to remote data source', () async {
      // arrange
      when(mockRemoteDataSource!.addUser(tUser)).thenAnswer((_) async => tUser);
      // act
      final result = await repository!.addUser(tUser);
      // assert
      verify(mockRemoteDataSource!.addUser(tUser));
      expect(result, equals(Right(tUser)));
    });

    test('should return server failure when remote call is unsuccessful',
        () async {
      // arrange
      when(mockRemoteDataSource!.addUser(tUser)).thenThrow(ServerException());
      // act
      final result = await repository!.addUser(tUser);
      // assert
      verify(mockRemoteDataSource!.addUser(tUser));
      expect(result, equals(Left(ServerFailure())));
    });
  });

  group('getUserById', () {
    final tUser = UserModel(
        id: '1',
        userName: 'testuser',
        email: 'testuser@example.com',
        fullName: 'Test User',
        expertise: 'Test Expertise',
        aboutMe: 'Test about me',
        followersCount: 10,
        followingCount: 20,
        profilePicture: 'http://example.com/profile.png');

    test('should get user from remote data source', () async {
      // arrange
      when(mockRemoteDataSource!.getUserById(tUser.id))
          .thenAnswer((_) async => tUser);
      // act
      final result = await repository!.getUserById(tUser.id);
      // assert
      verify(mockRemoteDataSource!.getUserById(tUser.id));
      expect(result, equals(Right(tUser)));
    });

    test('should return server failure when remote call is unsuccessful',
        () async {
      // arrange
      when(mockRemoteDataSource!.getUserById(tUser.id))
          .thenThrow(ServerException());
      // act
      final result = await repository!.getUserById(tUser.id);
      // assert
      verify(mockRemoteDataSource!.getUserById(tUser.id));
      expect(result, equals(Left(ServerFailure())));
    });
  });

  group('editUserById', () {
    final tUser = UserModel(
        id: '1',
        userName: 'testuser',
        email: 'testuser@example.com',
        fullName: 'Test User',
        expertise: 'Test Expertise',
        aboutMe: 'Test about me',
        followersCount: 10,
        followingCount: 20,
        profilePicture: 'http://example.com/profile.png');

    test('should edit user in remote data source', () async {
      // arrange
      when(mockRemoteDataSource!.editUserById(tUser))
          .thenAnswer((_) async => tUser);
      // act
      final result = await repository!.editUserById(tUser);
      // assert
      verify(mockRemoteDataSource!.editUserById(tUser));
      expect(result, equals(Right(tUser)));
    });

    test('should return server failure when remote call is unsuccessful',
        () async {
      // arrange
      when(mockRemoteDataSource!.editUserById(tUser))
          .thenThrow(ServerException());
      // act
      final result = await repository!.editUserById(tUser);
      // assert
      verify(mockRemoteDataSource!.editUserById(tUser));
      expect(result, equals(Left(ServerFailure())));
    });
  });

  group('deleteUserById', () {
    final tId = '1';

    test('should delete user in remote data source', () async {
      // arrange
      // act
      final result = await repository!.deleteUserById(tId);
      // assert
      verify(mockRemoteDataSource!.deleteUserById(tId));
      expect(result, equals(const Right(null)));
    });

    test('should return server failure when remote call is unsuccessful',
        () async {
      // arrange
      when(mockRemoteDataSource!.deleteUserById(tId))
          .thenThrow(ServerException());
      // act
      final result = await repository!.deleteUserById(tId);
      // assert
      verify(mockRemoteDataSource!.deleteUserById(tId));
      expect(result, equals(Left(ServerFailure())));
    });
  });
}
