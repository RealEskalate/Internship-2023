import '../../domain/entities/user.dart';

class LoginModel extends AuthUser {
  final String id;
  const LoginModel(
      {required super.email, required super.password, required this.id});

  factory LoginModel.fromJson(Map<String, dynamic> json) {
    return LoginModel(
        email: json["email"], password: json["password"], id: json["id"]);
  }

  Map<String, dynamic> toJson() {
    return {"email": email, "password": password, "id": id};
  }
}
