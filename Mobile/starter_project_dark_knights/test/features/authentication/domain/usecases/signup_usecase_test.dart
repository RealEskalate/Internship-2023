import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
import 'package:dark_knights/features/Authentication/domain/usecases/signupUsecase.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'login_usecase_test.mocks.dart';

@GenerateMocks([AuthenticationRepository])
void main() {
  late SignupUseCase signupUseCase;
  late MockAuthenticationRepository mockRepository;

  setUp(() {
    mockRepository = MockAuthenticationRepository();
    signupUseCase = SignupUseCase(mockRepository);
  });

  test('should return an Either object from the repository', () async {
    final newUser = Authentication(
      password: 'newtestpassword',
      userName: 'newtestuser',
    );
    when(mockRepository.signup(newUser))
        .thenAnswer((_) async => Right(newUser));

    final result = await signupUseCase(newUser);

    expect(result, Right(newUser));
    verify(mockRepository.signup(newUser));
    verifyNoMoreInteractions(mockRepository);
  });
}
