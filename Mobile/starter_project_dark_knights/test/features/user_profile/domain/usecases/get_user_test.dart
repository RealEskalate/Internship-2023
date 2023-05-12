import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

void main() {
  late MockUserRepository mockUserRepository;
  late GetUser usecase;
  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetUser(mockUserRepository);
  });
  final user = UserEntity(
      id: "user_123",
      username: "@jhon",
      firstName: "jhon",
      lastName: "abe",
      occupation: "designer",
      selfDescription: "I love design",
      password: "123",
      image: "someUrl");
  test('should get user details', () async {
    when(mockUserRepository.getUser("user_123"))
        .thenAnswer((_) async => Right(user));

    final result = await usecase("user_123");

    expect(result, Right(user));
    verify(mockUserRepository.getUser("user_123"));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
