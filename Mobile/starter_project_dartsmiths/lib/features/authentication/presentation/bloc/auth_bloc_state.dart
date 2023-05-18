part of 'auth_bloc.dart';

abstract class AuthBlocState extends Equatable {
  const AuthBlocState();

  @override
  List<Object> get props => [];
}

class AuthBlocInitial extends AuthBlocState {}

class AuthBlocLoading extends AuthBlocState {}

class AuthBlocLoginSuccess extends AuthBlocState {
  final String username;
  final String password;
  AuthBlocLoginSuccess({required this.username, required this.password});
}

class AuthBlocLoginFailure extends AuthBlocState {}
