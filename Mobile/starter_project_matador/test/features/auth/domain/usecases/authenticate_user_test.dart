import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/repositories/login_repository.dart';
import 'package:matador/features/auth/domain/usecases/login_use_case.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import '../../../user/domain/usecases/get_user_by_id_test.mocks.dart';
import 'authenticate_user_test.mocks.dart';

@GenerateMocks([LoginUserRepository])
void main() {
  LoginUserUseCase? usecase;
  MockLoginUserRepository? mockLoginUserRepository;
  setUp(() {
    mockLoginUserRepository = MockLoginUserRepository();
    usecase = LoginUserUseCase(mockLoginUserRepository);
  });
  const email = 'test@gmail.com';
  const password = 'password';
  final tuser = AuthUser(email: 'test@gmail.com', password: 'password');
  test('should get the user from the user repository', () async {
    //arrange
    when(mockLoginUserRepository!.authenticate('test@gmail.com', 'password'))
        .thenAnswer((_) async => Right(tuser));
    //act
    final result =
        await usecase!(const AuthParams(email: email, password: password));
    //assert
    expect(result, Right(tuser));
    verify(mockLoginUserRepository!.authenticate(email, password));
    verifyNoMoreInteractions(mockLoginUserRepository);
  });
}
