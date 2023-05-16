import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/core/network_info.dart';
import 'package:dartsmiths/features/profile/data/datasources/user_profile_remote_data_source.dart';
import 'package:dartsmiths/features/profile/data/models/user_profile_models.dart';
import 'package:dartsmiths/features/profile/data/repositories/user_profile_repo_impl.dart';
import 'package:dartsmiths/features/profile/domain/entities/user_profile.dart';
import 'package:flutter_test/flutter_test.dart';

import 'package:mockito/mockito.dart';
import 'package:dartz/dartz.dart';

class MockUserProfileRemoteDataSource extends Mock
    implements UserProfileRemoteDataSource {}

class MockNetworkInfo extends Mock implements NetworkInfo {}

void main() {
  late UserProfleRepositoryImpl repository;
  late MockUserProfileRemoteDataSource mockRemoteDataSource;
  late MockNetworkInfo mockNetworkInfo;

  setUp(() {
    mockRemoteDataSource = MockUserProfileRemoteDataSource();
    mockNetworkInfo = MockNetworkInfo();
    repository = UserProfleRepositoryImpl(
      mockRemoteDataSource,
      mockNetworkInfo,
    );
  });

  group('getUserProfile', () {
    const id = '123';

    test('should return user profile when network is available', () async {
      // Arrange
      final userProfile = UserProfileModel(
          profilePicture: "profilePicture",
          fullName: "fullName",
          userName: "userName",
          career: "career",
          bio: "bio",
          userFollower: 1,
          userFollowing: 1,
          numberOfPosts: 1);
      when(mockNetworkInfo.isNetworkAvailable()).thenAnswer((_) async => true);
      when(mockRemoteDataSource.getUserProfile(id))
          .thenAnswer((_) async => userProfile);

      // Act
      final result = await repository.getUserProfile(id);

      // Assert
      expect(result, equals(Right(userProfile)));
      verify(mockNetworkInfo.isNetworkAvailable()).called(1);
      verify(mockRemoteDataSource.getUserProfile(id)).called(1);
    });

    test('should return a NetworkFailure when network is unavailable',
        () async {
      // Arrange
      when(mockNetworkInfo.isNetworkAvailable()).thenAnswer((_) async => false);

      // Act
      final result = await repository.getUserProfile(id);

      // Assert
      expect(result, equals(Left(ServerFailure())));
      verify(mockNetworkInfo.isNetworkAvailable()).called(1);
      verifyZeroInteractions(mockRemoteDataSource);
    });
  });
}
