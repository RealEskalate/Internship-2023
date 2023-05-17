import 'dart:io';

import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';
import 'package:dartsmiths/features/authentication/domain/repository/login_repository.dart';
import 'package:dartsmiths/features/authentication/domain/use_cases/login_usecase.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'login_usecase.test.mocks.dart';

@GenerateMocks([AuthenticationRepository])
void main() {
  late LoginUsecase usecase;
  late MockAuthenticationRepository mockLoginRepository;

  setUp(() {
    mockLoginRepository = MockAuthenticationRepository();
    usecase = LoginUsecase(mockLoginRepository);
  });

  String tUserName = "Dartsmith";
  String tPassword = "582023";

  final user = UserAuthCredential(username:tUserName, password:tPassword);

  test('should get user name and password', () async {
    when(mockLoginRepository.login(password: tPassword, username: tUserName))
        .thenAnswer((_) async => Right(user));

    final result = await usecase(UserAuthCredentialParams(password: tPassword,username: tUserName));

    expect(result, Right(user));

    verify(mockLoginRepository.login(username: tUserName, password: tPassword));

    verifyNoMoreInteractions(mockLoginRepository);
  });
}
