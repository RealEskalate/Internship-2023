import 'package:dartsmiths/core/error/exceptions.dart';
import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/core/network/network_info.dart';
import 'package:dartsmiths/features/authentication/data/datasource/authentication_remote_datasource.dart';
import 'package:dartsmiths/features/authentication/data/model/user_auth_credentials.dart';
import 'package:dartsmiths/features/authentication/data/repository/authentication_repository_impl.dart';
import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';
import 'package:dartsmiths/features/authentication/domain/repository/login_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'auth_repository_test.mocks.dart';


@GenerateMocks([AuthenticationRemoteDataSource,NetworkInfo])
void main() {
  late AuthenticationRepositoryImpl repository;
  late MockAuthenticationRemoteDataSource mockRemoteDataSource;
  late MockNetworkInfo mockNetworkInfo;

  setUp(() {
    mockRemoteDataSource = MockAuthenticationRemoteDataSource();
    mockNetworkInfo = MockNetworkInfo();
    repository = AuthenticationRepositoryImpl(
        remotedataSource: mockRemoteDataSource, networkInfo: mockNetworkInfo);
  });

  group('login', () {
    const tUserName = 'testUser';
    const tPassword = 'testPassword';
    final tUserAuthCredentialModel =
        UserAuthCredentialsModel(password: tPassword, username: tUserName);
    final tUserAuthCredential = tUserAuthCredentialModel;

    group('device is online', () {
      setUp(() {
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => true);
      });

      test(
          'should return UserAuthCredential when the call to remote data source is successful',
          () async {
        // Arrange
        when(mockRemoteDataSource.login(any, any))
            .thenAnswer((_) async => tUserAuthCredentialModel);

        // Act
        final result =
            await repository.login(username: tUserName, password: tPassword);

        // Assert
        verify(mockRemoteDataSource.login(tUserName, tPassword));
        expect(result, equals(Right(tUserAuthCredential)));
      });

      test(
          'should return ServerFailure when the call to remote data source is unsuccessful',
          () async {
        // Arrange
        when(mockRemoteDataSource.login(any, any)).thenThrow(ServerException());

        // Act
        final result =
            await repository.login(username: tUserName, password: tPassword);

        // Assert
        verify(mockRemoteDataSource.login(tUserName, tPassword));
        expect(result, equals(Left(ServerFailure())));
      });
    });

    group('device is offline', () {
      setUp(() {
        when(mockNetworkInfo.isConnected).thenAnswer((_) async => false);
      });

      test('should return NetworkFailure when the device is offline', () async {
        // Act
        final result =
            await repository.login(username: tUserName, password: tPassword);

        // Assert
        verifyZeroInteractions(mockRemoteDataSource);
        expect(result, equals(Left(NetworkFailure())));
      });
    });
  });
}
