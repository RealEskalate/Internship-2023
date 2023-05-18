import 'package:matador/features/user/domain/entities/user.dart';

class UserModel extends User {
  String id;
  String userName;
  String email;
  String fullName;
  String? expertise;
  String? aboutMe;
  int followersCount;
  int followingCount;
  String? profilePicture;

  UserModel(
      {required this.id,
      required this.userName,
      required this.email,
      required this.fullName,
      this.expertise,
      this.aboutMe,
      this.followersCount = 0,
      this.followingCount = 0,
      this.profilePicture})
      : super(
          id: id,
          userName: userName,
          email: email,
          fullName: fullName,
          expertise: expertise,
          aboutMe: aboutMe,
          followersCount: followersCount,
          followingCount: followingCount,
        );

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      id: json['id'],
      userName: json['userName'],
      email: json['email'],
      fullName: json['fullName'],
      expertise: json['expertise'],
      aboutMe: json['aboutMe'],
      followersCount: json['followersCount'],
      followingCount: json['followingCount'],
      profilePicture: json['profilePicture']
    );
  }

  Map<String, dynamic> toJson() {
    return {
      "id": id,
      "userName": userName,
      "email": email,
      "fullName": fullName,
      "expertise": expertise,
      "aboutMe": aboutMe,
      "followersCount": followersCount,
      "followingCount": followingCount,
      "profilePicture": profilePicture,

    };
  }
}
