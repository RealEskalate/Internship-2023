part of 'authentication_bloc.dart';

abstract class AuthenticationState extends Equatable {
  const AuthenticationState();

  @override
  List<Object> get props => [];
}

class AuthenticationInitial extends AuthenticationState {}

class AuthenticationLoading extends AuthenticationState {}

class AuthenticationSuccess extends AuthenticationState {
  final Authentication authentication;

  const AuthenticationSuccess({required this.authentication});

  @override
  List<Object> get props => [authentication];
}

class AuthenticationFailure extends AuthenticationState {
  final Failure error;

  const AuthenticationFailure({required this.error});

  @override
  List<Object> get props => [error];
}
