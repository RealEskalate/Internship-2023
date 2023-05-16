import 'package:dartsmiths/features/profile/data/models/user_profile_models.dart';
import 'package:dartsmiths/features/profile/domain/entities/user_profile.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/annotations.dart';

@GenerateMocks([UserProfileModel])
void main() {
  final userProfile = UserProfileModel(
      profilePicture: "profilePicture",
      fullName: "fullName",
      userName: "userName",
      career: "career",
      bio: "bio",
      userFollower: 1,
      userFollowing: 1,
      numberOfPosts: 1);
  final json = {
    "profilePicture": "profilePicture",
    "fullName": "fullName",
    "userName": "userName",
    "career": "career",
    "bio": "bio",
    "userFollower": 1,
    "userFollowing": 1,
    "numberOfPosts": 1
  };

  test("Shoud be a subclass of User profile enitity", () {
    expect(userProfile, isA<UserProfile>());
  });
  test("should change from json to model", () {
    final result = UserProfileModel.fromJson(json);
    expect(userProfile, result);
  });
  test("should change from model to json", () {
    final result = userProfile.toJson();
    expect(json, result);
  });
}
