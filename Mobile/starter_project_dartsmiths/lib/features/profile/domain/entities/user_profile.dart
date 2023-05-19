import 'package:equatable/equatable.dart';

class UserProfile extends Equatable {
  final String profilePicture;
  final String fullName;
  final String userName;
  final String career;
  final String bio;
  final int userFollower;
  final int userFollowing;
  final int numberOfPosts;

  const UserProfile(
      {required this.profilePicture,
      required this.fullName,
      required this.userName,
      required this.career,
      required this.bio,
      required this.userFollower,
      required this.userFollowing,
      required this.numberOfPosts})
      : super();

  @override
  List<Object> get props => [
        profilePicture,
        fullName,
        userName,
        career,
        userFollower,
        userFollowing,
        numberOfPosts
      ];
}
