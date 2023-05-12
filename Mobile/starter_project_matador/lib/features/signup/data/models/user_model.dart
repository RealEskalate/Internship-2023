import 'package:meta/meta.dart';

import 'package:matador/features/signup/domain/entities/user.dart';

class UserModel extends User {
  UserModel({required String email, required String password})
      : super(email: email, password: password);

  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(email: json['email'], password: json['password']);
  }

  Map<String, dynamic> toJson() {
    return {'email': email, 'password': password};
  }
}
