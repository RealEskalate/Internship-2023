import '../../domain/entities/user.dart';

abstract class LoginState {}

class LoginInitialState extends LoginState {}

class LoginLoadingState extends LoginState {}

class LoginSuccessState extends LoginState {
  final String id;
  LoginSuccessState({required this.id});
}

class LoginFailureState extends LoginState {
  final String error;
  LoginFailureState({required this.error});
}
