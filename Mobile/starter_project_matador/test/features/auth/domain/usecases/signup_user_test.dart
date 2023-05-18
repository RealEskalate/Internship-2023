// ignore: import_of_legacy_library_into_null_safe
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/repositories/signup_repository.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:matador/features/auth/domain/usecases/signup_user.dart';

import 'signup_user_test.mocks.dart';

@GenerateMocks([SignUpRepository])
void main() {
  late SignUpUser signUpUser;
  late MockSignUpRepository mocksignupRepository;

  setUp(() {
    mocksignupRepository = MockSignUpRepository();
    signUpUser = SignUpUser(mocksignupRepository);
  });

  final tEmail = 'test@example.com';
  final tPassword = 'test123';
  final tUser = AuthUser(email: tEmail, password: tPassword);

  test('should sign up user with the provided email and password', () async {
    // arrange
    when(mocksignupRepository.register(tEmail, tPassword))
        .thenAnswer((_) async => Right(tUser));

    // act
    final result =
        await signUpUser(SignUpParams(email: tEmail, password: tPassword));

    // assert
    expect(result, Right(tUser));

    verify(mocksignupRepository.register(tEmail, tPassword));

    verifyNoMoreInteractions(mocksignupRepository);
  });
}
