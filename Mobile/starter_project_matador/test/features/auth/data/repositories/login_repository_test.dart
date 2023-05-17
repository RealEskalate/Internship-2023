import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exception.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/login/Domain/entities/user.dart';
import 'package:matador/features/login/data/datasources/login_remote_datasource.dart';
import 'package:matador/features/login/data/models/login_model.dart';
import 'package:matador/features/login/data/repositories/login_user_repository_impl.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'login_repository_test.mocks.dart';

@GenerateMocks([LoginUserRemoteDataSource])
void main() {
  late LoginUserRepositoryImpl repository;
  late MockLoginUserRemoteDataSource mockRemoteDataSource;

  setUp(() {
    mockRemoteDataSource = MockLoginUserRemoteDataSource();
    repository =
        LoginUserRepositoryImpl(remoteDataSource: mockRemoteDataSource);
  });

  test(
      'should return a LoginModel when the call to remote data source is successful',
      () async {
    // arrange
    final tEmail = 'test@test.com';
    final tPassword = 'test123';
    final tLoginModel = LoginModel(email: tEmail, password: tPassword);
    when(mockRemoteDataSource.authenticate(tLoginModel))
        .thenAnswer((_) async => tLoginModel);
    // act
    final result = await repository.authenticate(tEmail, tPassword);
    // assert
    verify(mockRemoteDataSource.authenticate(tLoginModel));
    expect(result, equals(Right(tLoginModel)));
  });
  test(
      'should return server failure when the call to remote data source is unsuccessful',
      () async {
    // arrange
    final tEmail = 'test@test.com';
    final tPassword = 'test123';
    when(mockRemoteDataSource.authenticate(any)).thenThrow(ServerException());
    // act
    final result = await repository.authenticate(tEmail, tPassword);
    // assert
    verify(mockRemoteDataSource
        .authenticate(LoginModel(email: tEmail, password: tPassword)));
    expect(result, equals(Left(ServerFailure())));
  });
}
