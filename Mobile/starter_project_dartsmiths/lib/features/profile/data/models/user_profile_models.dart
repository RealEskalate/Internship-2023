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
      : super();

  factory UserProfileModel.fromJson(Map<String, dynamic> json) {
    return UserProfileModel(
        profilePicture: json["profilePicture"],
        fullName: json["fullName"],
        userName: json["userName"],
        career: json["career"],
        bio: json["bio"],
        userFollower: json["userFollower"],
        userFollowing: json["userFollowing"],
        numberOfPosts: json["numberOfPosts"]);
  }
  Map<String, dynamic> toJson() {
    return {
      'profilePicture': profilePicture,
      'fullName': fullName,
      'userName': userName,
      'career': career,
      'bio': bio,
      'userFollower': userFollower,
      'userFollowing': userFollowing,
      'numberOfPosts': numberOfPosts
    };
  }
}
