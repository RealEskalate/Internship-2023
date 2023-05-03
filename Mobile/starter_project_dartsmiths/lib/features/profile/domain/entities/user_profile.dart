import 'package:equatable/equatable.dart';

class UserProfile extends Equatable {
  final String profilePicture;
  final String fullName;
  final String userName;
  final String career;

  UserProfile(
      {required this.profilePicture,
      required this.fullName,
      required this.userName,
      required this.career})
      : super([profilePicture, fullName, userName, career]);
}
