import '../../domain/entities/info_detail.dart';

class InfoDetailModel extends InfoDetail {
  

  InfoDetailModel({
    required super.id,
    required super.userId,
    required super.classId,
    required super.title,
    required super.description,
    required super.archives,
    required super.tags,
    // required this.createdAt,
    // required this.updatedAt,
    required super.isFavorite,
  });

  factory InfoDetailModel.fromJson(Map<String, dynamic> json) {
    return InfoDetailModel(
      id: json['_id'],
      userId: User.fromJson(json['userId']),
      classId: json['classId'],
      title: json['title'],
      description: json['description'],
      archives: List<Archive>.from(json['archives'].map((archive) => Archive.fromJson(archive))),
      tags: List<String>.from(json['tags']),
      // createdAt: DateTime.parse(json['createdAt']),
      // updatedAt: DateTime.parse(json['updatedAt']),
      isFavorite: json['isFavorite'],
    );
  }
}

class User {
  String id;
  String email;
  String userName;
  String name;
  String password;
  String bio;
  String country;
  String avatar;
  List<String> favoriteTags;
  String resetToken;
  // DateTime createdAt;
  // DateTime updatedAt;

  User({
    required this.id,
    required this.email,
    required this.userName,
    required this.name,
    required this.password,
    required this.bio,
    required this.country,
    required this.avatar,
    required this.favoriteTags,
    required this.resetToken,
    // required this.createdAt,
    // required this.updatedAt,
  });

  factory User.fromJson(Map<String, dynamic> json) {
    return User(
      id: json['_id'],
      email: json['email'],
      userName: json['userName'],
      name: json['name'],
      password: json['password'],
      bio: json['bio'],
      country: json['country'],
      avatar: json['avatar'],
      favoriteTags: List<String>.from(json['favoriteTags']),
      resetToken: json['resetToken'],
      // createdAt: DateTime.parse(json['createdAt']),
      // updatedAt: DateTime.parse(json['updatedAt']),
    );
  }
}

class Archive {
  String id;
  String name;
  String fileAddress;
  String cloudinaryId;
  // DateTime createdAt;
  // DateTime updatedAt;

  Archive({
    required this.id,
    required this.name,
    required this.fileAddress,
    required this.cloudinaryId,
    // required this.createdAt,
    // required this.updatedAt,
  });

  factory Archive.fromJson(Map<String, dynamic> json) {
    return Archive(
      id: json['_id'],
      name: json['name'],
      fileAddress: json['fileAddress'],
      cloudinaryId: json['cloudinaryId'],
      // createdAt: DateTime.parse(json['created_at']),
      // updatedAt: DateTime.parse(json['updated_at']),
    );
  }
}