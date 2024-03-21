import 'package:equatable/equatable.dart';

class AuthUser extends Equatable {
  final String email;
  final String password;
  const AuthUser({required this.email, required this.password});

  @override
  List<Object?> get props => ([email, password]);
}
