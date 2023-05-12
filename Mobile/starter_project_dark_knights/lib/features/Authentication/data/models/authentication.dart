import '../../domain/entities/authentication_entitiy.dart';

class AuthenticationModel extends Authentication {
  String id;
  String userName;
  String password;

  AuthenticationModel(
      {required this.id, required this.userName, required this.password})
      : super(password: '123', userName: 'USER');

  factory AuthenticationModel.fromJson(Map<String, dynamic> json) {
    return AuthenticationModel(
      id: json['id'],
      userName: json['userName'],
      password: json['password'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'userName': userName,
      'password': password,
    };
  }
}
