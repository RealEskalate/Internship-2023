import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
// import 'package:dark_knights/features/Authentication/domain/usecases/signupUsecase.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:dark_knights/features/Authentication/domain/usecases/loginUsecase.dart';
import 'login_usecase_test.mocks.dart';

@GenerateMocks([AuthenticationRepository])
void main() {
  late LoginUseCase loginUseCase;
  late MockAuthenticationRepository mockRepository;

  setUp(() {
    mockRepository = MockAuthenticationRepository();
    loginUseCase = LoginUseCase(mockRepository);
  });
  test("description", () async {
    final user = Authentication(password: "password", userName: "userName");

    when(mockRepository.login(user)).thenAnswer((_) async => Right(user));

    final result = await loginUseCase(user);
    expect(result, Right(user));
    verify(mockRepository.login(user));
    verifyNoMoreInteractions(mockRepository);
  });
}
