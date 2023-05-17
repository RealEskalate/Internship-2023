part of 'auth_bloc_bloc.dart';

abstract class AuthBlocEvent extends Equatable {
  const AuthBlocEvent();

  @override
  List<Object> get props => [];
}

class LoginEvent extends AuthBlocEvent {
  final String username;
  final String password;

  const LoginEvent({required this.username, required this.password});
}
