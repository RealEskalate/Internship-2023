import 'package:bloc/bloc.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dark_knights/features/Authentication/domain/repositories/authentication_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';

part 'authentication_event.dart';
part 'authentication_state.dart';

class AuthenticationBloc
    extends Bloc<AuthenticationEvent, AuthenticationState> {
  final AuthenticationRepository repository;

  AuthenticationBloc({required this.repository})
      : super(AuthenticationInitial()) {
    on<LoginEvent>((event, emit) async {
      emit(AuthenticationLoading());
      final result = await repository.login(event.authCredentials);
      if (result == Right(Failure)) {
        emit(AuthenticationError(error: result));
      } else {
        emit(AuthenticationSuccess(authentication: result));
      }
    });
  }

  @override
  Stream<AuthenticationState> mapEventToState(
    AuthenticationEvent event,
  ) async* {
    if (event is LoginEvent) {
      yield AuthenticationLoading();
      final result = await repository.login(event.authCredentials);
      yield result.fold(
        (failure) => AuthenticationError(message: failure.message),
        (authentication) =>
            AuthenticationSuccess(authentication: authentication),
      );
    } else if (event is SignupEvent) {
      yield AuthenticationLoading();
      final result = await repository.signup(event.newuser);
      yield result.fold(
        (failure) => AuthenticationError(message: failure.message),
        (authentication) =>
            AuthenticationSuccess(authentication: authentication),
      );
    }
  }
}

// import 'package:flutter_bloc/flutter_bloc.dart';
// import 'package:frontend/repository/secure_storage.dart';
// import 'package:frontend/blocs/auth/AuthEvent.dart';
// import 'package:frontend/blocs/auth/AuthState.dart';

// class AuthBloc extends Bloc<AuthEvent, AuthState> {
//   final StorageService storage;
//   AuthBloc(this.storage) : super(AuthInitital()) {
//     on<CheckLogIn>((event, emit) async {
//       final bool hasToken = await storage.hasToken();
//       if (hasToken) {
//         final String? token = await storage.getToken();
//         final String? id = await storage.getId();
//         final String? role = await storage.getRole();
//         emit(Authenticated(role!, id!));
//       }
//     });
//     on<LoggedIn>(
//       (event, emit) async {
//         emit(AuthLoading());
//         print(event.role);
//         await storage.saveIdAndToken(event.role!, event.id!, event.token!);
//         emit(Authenticated(event.role!, event.id!));
//       },
//     );
//     on<LogOut>(
//       (event, emit) async {
//         emit(AuthLoggingOut());
//         await storage.deleteAll();
//         emit(AuthInitital());
//       },
//     );
//   }
// }