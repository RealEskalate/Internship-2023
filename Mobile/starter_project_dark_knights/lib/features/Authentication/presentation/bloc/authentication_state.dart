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

class AuthenticationError extends AuthenticationState {
  final Failure error;

  const AuthenticationError({required this.error});

  @override
  List<Object> get props => [message];
}
