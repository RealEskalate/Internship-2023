import '../../Domain/entities/user.dart';

class LoginModel extends User {
  const LoginModel({required super.email, required super.password});

  factory LoginModel.fromJson(Map<String, dynamic> json) {
    return LoginModel(email: json["email"], password: json["password"]);
  }
  Map<String, dynamic> toJson() {
    return {
      "email": email,
      "password": password,
    };
  }
}