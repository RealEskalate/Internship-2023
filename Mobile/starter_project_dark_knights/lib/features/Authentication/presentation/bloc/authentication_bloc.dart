import 'package:bloc/bloc.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
import 'package:dark_knights/features/Authentication/domain/usecases/signupUsecase.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';

import '../../domain/usecases/loginUsecase.dart';

part 'authentication_event.dart';
part 'authentication_state.dart';

class AuthenticationBloc
    extends Bloc<AuthenticationEvent, AuthenticationState> {
  final LoginUseCase loginUseCase;
  final SignupUseCase signupUseCase;

  AuthenticationBloc({
    required this.loginUseCase,
    required this.signupUseCase,
  }) : super(AuthenticationInitial()) {
    on<LoginEvent>(_login);
    on<SignupEvent>(_signup);
  }

  void _login(LoginEvent event, Emitter<AuthenticationState> emit) async {
    emit(AuthenticationLoading());
    final result = await loginUseCase(event.authCredentials);
    emit(_loginSuccessOrFailure(result));
  }

  void _signup(SignupEvent event, Emitter<AuthenticationState> emit) async {
    emit(AuthenticationLoading());
    final result = await signupUseCase(event.newAuthCredentials);
    emit(_signupSuccessOrFailure(result));
  }

  AuthenticationState _loginSuccessOrFailure(
      Either<Failure, Authentication> data) {
    return data.fold((failure) => AuthenticationFailure(error: failure),
        (success) => AuthenticationSuccess(authentication: success));
  }

  AuthenticationState _signupSuccessOrFailure(
      Either<Failure, Authentication> data) {
    return data.fold((failure) => AuthenticationFailure(error: failure),
        (success) => AuthenticationSuccess(authentication: success));
  }
}
