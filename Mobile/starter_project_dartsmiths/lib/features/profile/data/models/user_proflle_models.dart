import '../../domain/entities/user_profile.dart';

class UserProfileModel extends UserProfile {
  UserProfileModel(
      {required super.profilePicture,
      required super.fullName,
      required super.userName,
      required super.career,
      required super.bio,
      required super.userFollower,
      required super.userFollowing,
      required super.numberOfPosts})
      : super([]);
}
