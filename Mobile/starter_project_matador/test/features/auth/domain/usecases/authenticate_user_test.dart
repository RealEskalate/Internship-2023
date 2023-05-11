import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:matador/core/usecases/usecases.dart';
import 'package:matador/features/login/Domain/entities/user.dart';
import 'package:matador/features/login/Domain/repositories/user_repository.dart';
import 'package:matador/features/login/Domain/usecases/login_use_case.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';

import 'authenticate_user_test.mocks.dart';

@GenerateMocks([UserRepository])
void main() {
  GetUser? usecase;
  MockUserRepository? mockUserRepository;
  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetUser(mockUserRepository);
  });
  const email = 'test@gmail.com';
  const password = 'password';
  final tuser = User(email: 'test@gmail.com', password: 'password');
  test('should get the user from the user repository', () async {
    //arrange
    when(mockUserRepository!.authenticate('test@gmail.com', 'password'))
        .thenAnswer((_) async => Right(tuser));
    //act
    final result =
        await usecase!(const AuthParams(email: email, password: password));
    //assert
    expect(result, Right(tuser));
    verify(mockUserRepository!.authenticate(email, password));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
