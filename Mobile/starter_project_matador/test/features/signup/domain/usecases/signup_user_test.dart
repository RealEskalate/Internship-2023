// ignore: import_of_legacy_library_into_null_safe
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:matador/features/signup/domain/entities/user.dart';
import 'package:matador/features/signup/domain/repositories/auth_repository.dart';
import 'package:matador/features/signup/domain/usecases/signup_user.dart';

import 'signup_user_test.mocks.dart';

@GenerateMocks([AuthRepository])
void main() {
  late SignUpUser signUpUser;
  late MockAuthRepository mockAuthRepository;

  setUp(() {
    mockAuthRepository = MockAuthRepository();
    signUpUser = SignUpUser(mockAuthRepository);
  });

  final tEmail = 'test@example.com';
  final tPassword = 'test123';
  final tUser = User(email: tEmail, password: tPassword);

  test('should sign up user with the provided email and password', () async {
    // arrange
    when(mockAuthRepository.signUp(tEmail, tPassword))
        .thenAnswer((_) async => Right(tUser));

    // act
    final result =
        await signUpUser(SignUpParams(email: tEmail, password: tPassword));

    // assert
    expect(result, Right(tUser));

    verify(mockAuthRepository.signUp(tEmail, tPassword));

    verifyNoMoreInteractions(mockAuthRepository);
  });
}
