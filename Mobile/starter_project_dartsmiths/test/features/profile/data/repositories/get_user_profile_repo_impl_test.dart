import 'package:dartsmiths/features/profile/data/datasources/user_profile_remote_data_source.dart';
import 'package:dartsmiths/features/profile/data/models/user_profile_models.dart';
import 'package:dartsmiths/features/profile/data/repositories/user_profile_repo_impl.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';

import 'package:mockito/mockito.dart';
import 'package:dartz/dartz.dart';

import 'get_user_profile_repo_impl_test.mocks.dart';

@GenerateMocks([UserProfileRemoteDataSource])
void main() {
  late UserProfleRepositoryImpl repository;
  late MockUserProfileRemoteDataSource mockRemoteDataSource;

  setUp(() {
    mockRemoteDataSource = MockUserProfileRemoteDataSource();
    repository = UserProfleRepositoryImpl(
      mockRemoteDataSource,
    );
  });

  group('getUserProfile', () {
    const id = '123';

    test('should return user profile when network is available', () async {
      // Arrange

      const userProfile = UserProfileModel(
          profilePicture: "profilePicture",
          fullName: "fullName",
          userName: "userName",
          career: "career",
          bio: "bio",
          userFollower: 1,
          userFollowing: 1,
          numberOfPosts: 1);

      when(mockRemoteDataSource.getUserProfile(id))
          .thenAnswer((_) async => userProfile);

      // Act
      final result = await repository.getUserProfile(id);

      // Assert
      expect(result, equals(Right(userProfile)));
      verify(mockRemoteDataSource.getUserProfile(id)).called(1);
    });
  });
}
