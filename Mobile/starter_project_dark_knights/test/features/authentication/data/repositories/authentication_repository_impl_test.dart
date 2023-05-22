import 'package:dark_knights/core/errors/exception.dart';
import 'package:dark_knights/features/Authentication/data/datasources/authenication_remote_data_sources.dart';
import 'package:dark_knights/features/Authentication/data/datasources/authentication_local_data_source.dart';
import 'package:dark_knights/features/Authentication/data/models/authentication.dart';
import 'package:dark_knights/features/Authentication/data/repositories/authentication_repository_impl.dart';
import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/network/network_info.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'authentication_repository_impl_test.mocks.dart';

@GenerateMocks([
  NetworkInfo,
  AuthenticationRemoteDataSource,
  AuthenticationLocalDataSource
])
void main() {
  late AuthenticationRepositoryImpl repository;
  late MockAuthenticationRemoteDataSource mockRemoteDataSource;
  late MockAuthenticationLocalDataSource mockLocalDataSource;
  late MockNetworkInfo mockNetworkInfo;

  setUp(() {
    mockRemoteDataSource = MockAuthenticationRemoteDataSource();
    mockLocalDataSource = MockAuthenticationLocalDataSource();
    mockNetworkInfo = MockNetworkInfo();
    repository = AuthenticationRepositoryImpl(
      remoteDataSource: mockRemoteDataSource,
      localDataSource: mockLocalDataSource,
      networkInfo: mockNetworkInfo,
    );
  });
  final testUser = Authentication(userName: 'testuser', password: 'testpass');
  final testResponse = AuthenticationModel(userName: 'testuser', password: 'testpass', id: '1');
  
  group('login', () {
   
   test('should return the authentication data when login is successful',
      () async {
    // Arrange
    when(mockRemoteDataSource.login(any)).thenAnswer((_) async => testResponse);

    // Act
    final result = await repository.login(testUser);

    // Assert
    expect(result, Right(testResponse));
  });
   test('should return a server failure when an exception occurs', () async {
    // Arrange
  
    when(mockRemoteDataSource.login(any)).thenThrow(ServerException("Internal Server Error."));

    // Act
    final result = await repository.login(testUser);

    // Assert
    expect(result, Left(ServerFailure("Internal Server Error.")));
  });
  });
group("signup", () {
test('should return the authentication data when signup is successful',
        () async {
      // Arrange
      when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
      when(mockRemoteDataSource.signup(any))
          .thenAnswer((_) async => testResponse);

      // Act
      final result = await repository.signup(testUser);

      // Assert
      expect(result, Right(testResponse));
    });

test('should return a server failure when an exception occurs', () async {
      // Arrange
      when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
      when(mockRemoteDataSource.signup(any)).thenThrow(ServerException("Internal Server Error."));

      // Act
      final result = await repository.signup(testUser);

      // Assert
      expect(result, Left(ServerFailure("Internal Server Error.")));
});});}

 
