import '../../domain/entities/user.dart';

abstract class LoginState {}

class LoginInitialState extends LoginState {}

class LoginLoadingState extends LoginState {}

class LoginSuccessState extends LoginState {
  final AuthUser authUser;
  LoginSuccessState({required this.authUser});
}

class LoginFailureState extends LoginState {
  final String error;
  LoginFailureState({required this.error});
}
