part of 'authentication_bloc.dart';

abstract class AuthenticationEvent extends Equatable {
  const AuthenticationEvent();

  @override
  List<Object> get props => [];
}

class LoginEvent extends AuthenticationEvent {
  final Authentication authCredentials;

  const LoginEvent({required this.authCredentials});

  @override
  List<Object> get props => [authCredentials];
}

class SignupEvent extends AuthenticationEvent {
  final Authentication newAuthCredentials;

  const SignupEvent({required this.newAuthCredentials});

  @override
  List<Object> get props => [newAuthCredentials];
}