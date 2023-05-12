import 'dart:ffi';

import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_followers.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'create_user_test.mocks.dart';

@GenerateMocks([UserRepository])
void main() {
  late MockUserRepository mockUserRepository;
  late GetFollower usecase;
  setUp(() {
    mockUserRepository = MockUserRepository();
    usecase = GetFollower(mockUserRepository);
  });
  test('should get followers', () async {
    final List<UserEntity> followers = [
      UserEntity(
        id: "1",
        username: 'johndoe',
        firstName: 'John',
        lastName: 'Doe',
        occupation: 'Software Developer',
        selfDescription: 'I love coding and building cool stuff!',
        password: 'password',
        image: 'https://example.com/johndoe.jpg',
      )
    ];

    when(mockUserRepository.getFollowers("user_123"))
        .thenAnswer((_) async => Right(followers));

    final result = await usecase("user_123");

    expect(result, Right(followers));
    verify(mockUserRepository.getFollowers("user_123"));
    verifyNoMoreInteractions(mockUserRepository);
  });
}
