import '../../domain/entity/authentication_payload.dart';

class UserAuthCredentialsModel extends UserAuthCredential {
  const UserAuthCredentialsModel(
      {required super.username, required super.password});

  factory UserAuthCredentialsModel.fromJson(Map<String, dynamic> json) {
    return UserAuthCredentialsModel(
        password: json["password"], username: json["username"]);
  }
  Map<String, dynamic> toJson() {
    return {"username": username, "password": password};
  }
}
