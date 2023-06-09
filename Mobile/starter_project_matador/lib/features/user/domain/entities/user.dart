import "package:equatable/equatable.dart";

class User extends Equatable {
  final String id;
  final String userName;
  final String email;
  final String fullName;
  final String? expertise;
  final String? aboutMe;
  final int followersCount;
  final int followingCount;
  final String? profilePicture;

  const User(
      {required this.id,
        required this.userName,
        required this.email,
        required this.fullName,
        this.expertise,
        this.aboutMe,
        this.followersCount = 0,
        this.followingCount = 0,
        this.profilePicture})
      : super();

  @override
  List<Object?> get props => [
    id,
    userName,
    email,
    fullName,
    expertise,
    followersCount,
    followingCount,
    profilePicture
  ];
}