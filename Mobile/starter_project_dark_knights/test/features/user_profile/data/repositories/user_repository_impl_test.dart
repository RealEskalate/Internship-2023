import 'dart:convert';
import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_local_data_source.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/data/repositories/user_repository_impl.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import '../../../../fixtures/fixture_reader.dart';
import 'user_repository_impl_test.mocks.dart';

@GenerateMocks([NetworkInfo, UserRemoteDataSource, UserLocalDataSource])
void main() {
  late UserRemoteDataSource mockRemoteDataSource;
  late UserLocalDataSource mockLocalDataSource;
  late NetworkInfo mockNetworkInfo;
  late UserRepositoryImpl repository;
  setUp(() {
    mockRemoteDataSource = MockUserRemoteDataSource();
    mockLocalDataSource = MockUserLocalDataSource();
    mockNetworkInfo = MockNetworkInfo();
    repository = UserRepositoryImpl(
        remoteDataSource: mockRemoteDataSource,
        localDataSource: mockLocalDataSource,
        networkInfo: mockNetworkInfo);
  });
  final fixtureData = fixture('user.json');
  final sampleInfo = json.decode(fixtureData);
  final tUserModel = UserModel.fromJson(sampleInfo);
  final UserEntity tUserEntity = tUserModel;
  const userId = "1";
  test("should return a user when the call to remote data source is successful",
      () async {
    when(mockRemoteDataSource.getUser(userId))
        .thenAnswer((_) async => tUserModel);
    final actualResult = await repository.getUser(userId);
    expect(actualResult, equals(Right(tUserEntity)));
  });

  test(
      "should return a list of users when the call to remote data source is successful",
      () async {
    // Arrange
    final fixtureData = fixture("list_of_users.json");
    final sampleInfo = json.decode(fixtureData);
    final userList = List<Map<String, dynamic>>.from(sampleInfo);
    final List<UserModel> tUsers = userList.map((json) => UserModel.fromJson(json)).toList();
    final List<UserEntity> tUserEntity = tUsers;
    when(mockRemoteDataSource.getAllUsers()).thenAnswer((_) async =>
        tUsers);
    // Act
    final actualResult = await repository.getAllUsers();

    // Assert
    expect(actualResult, equals(Right(tUserEntity)));
  });

  test(
      "should delete and return a user when the call to remote data source is successful",
      () async {
    when(mockRemoteDataSource.deleteUser(userId))
        .thenAnswer((_) async => tUserModel);
    final actualResult = await repository.deleteUser(userId);
    expect(actualResult, equals(Right(tUserEntity)));
  });
}
