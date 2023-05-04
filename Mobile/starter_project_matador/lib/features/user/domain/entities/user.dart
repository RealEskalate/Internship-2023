import "package:equatable/equatable.dart";

class User extends Equatable {
  final int id;
  final String userName;
  final String email;
  final String fullName;
  final String? expertise;
  final String? aboutMe;
  final int followers;
  final int following;
  final String? profilePicture;

  const User(
      {required this.id,
      required this.userName,
      required this.email,
      required this.fullName,
      this.expertise,
      this.aboutMe,
      this.followers = 0,
      this.following = 0,
      this.profilePicture})
      : super();

  @override
  List<Object?> get props => [
        id,
        userName,
        email,
        fullName,
        expertise,
        followers,
        following,
        profilePicture
      ];
}
