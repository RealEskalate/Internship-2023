import 'package:dartsmiths/features/profile/domain/entities/user_profile.dart';
import 'package:dartsmiths/features/profile/domain/repositories/user_profile_repository.dart';
import 'package:dartsmiths/features/profile/domain/usecases/get_user_profile.dart';
import 'package:dartz/dartz.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'get_user_profile_test.mocks.dart';

@GenerateMocks([UserProfileRepository])
void main() {
  late GetUserProfile usecase;
  late MockUserProfileRepository mockUserProfileRepository;
  setUp(() {
    mockUserProfileRepository = MockUserProfileRepository();
    usecase = GetUserProfile(mockUserProfileRepository);
  });

  String id = 'id';
  final userProfile = UserProfile(
      profilePicture: "profilePicture",
      fullName: "fullName",
      userName: "userName",
      career: "career");

  test('Should get user profile', () async {
    when(mockUserProfileRepository.getUserProfile(id))
        .thenAnswer((_) async => Right(userProfile));

    final result = await usecase.execute(id: id);

    expect(result, Right(userProfile));
    verify(mockUserProfileRepository.getUserProfile(id));
  });
}
