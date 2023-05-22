import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/exception.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/auth/data/datasources/login_remote_datasource.dart';
import 'package:matador/features/auth/data/models/login_model.dart';
import 'package:matador/features/auth/data/repositories/login_user_repository_impl.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'login_repository_test.mocks.dart';

@GenerateMocks([LoginRemoteDataSource])
void main() {
  MockLoginRemoteDataSource? mockRemoteDataSource;
  LoginUserRepositoryImpl? repository;

  setUp(() {
    mockRemoteDataSource = MockLoginRemoteDataSource();
    repository =
        LoginUserRepositoryImpl(remoteDataSource: mockRemoteDataSource!);
  });

  final email = 'test@example.com';
  final password = 'password';
  final id = '12345';
  final user = AuthUser(email: email, password: password);
  final loginModel = LoginModel(email: email, password: password, id: id);

  test('should return the user ID when the remote data source is successful',
      () async {
    when(mockRemoteDataSource!.authenticate(email, password))
        .thenAnswer((_) async => loginModel);

    final result = await repository!.authenticate(user);

    expect(result, Right(id));
    verify(mockRemoteDataSource!.authenticate(email, password));
    verifyNoMoreInteractions(mockRemoteDataSource);
  });

  test(
      'should return a ServerFailure when the remote data source throws a ServerException',
      () async {
    when(mockRemoteDataSource!.authenticate(email, password))
        .thenThrow(ServerException());

    final result = await repository!.authenticate(user);

    expect(result, Left(ServerFailure()));
    verify(mockRemoteDataSource!.authenticate(email, password));
    verifyNoMoreInteractions(mockRemoteDataSource);
  });
}
