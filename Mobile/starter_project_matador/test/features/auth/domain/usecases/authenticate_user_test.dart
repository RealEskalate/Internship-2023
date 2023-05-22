import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/repositories/login_repository.dart';
import 'package:matador/features/auth/domain/usecases/login_use_case.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'authenticate_user_test.mocks.dart';

@GenerateMocks([LoginUserRepository])
void main() {
  MockLoginUserRepository? mockRepository;
  LoginUserUseCase? useCase;

  setUp(() {
    mockRepository = MockLoginUserRepository();
    useCase = LoginUserUseCase(mockRepository!);
  });

  final email = 'test@example.com';
  final password = 'password';
  final id = '12345';
  final params = AuthParams(email: email, password: password);

  test('should return the user ID when the repository is successful', () async {
    when(mockRepository!.authenticate(any)).thenAnswer((_) async => Right(id));

    final result = await useCase!(params);

    expect(result, Right(id));
    verify(mockRepository!
        .authenticate(AuthUser(email: email, password: password)));
    verifyNoMoreInteractions(mockRepository);
  });

  test('should return a failure when the repository returns a failure',
      () async {
    when(mockRepository!.authenticate(any))
        .thenAnswer((_) async => Left(ServerFailure()));

    final result = await useCase!(params);

    expect(result, Left(ServerFailure()));
    verify(mockRepository!
        .authenticate(AuthUser(email: email, password: password)));
    verifyNoMoreInteractions(mockRepository);
  });
}
