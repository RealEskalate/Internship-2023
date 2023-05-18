import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:matador/features/auth/domain/entities/user.dart';
import 'package:matador/features/auth/domain/usecases/login_use_case.dart';

import 'login_event.dart';
import 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  final LoginUserUseCase _loginUser;

  LoginBloc({required LoginUserUseCase loginUseCase})
      : _loginUser = loginUseCase,
        super(LoginInitialState()) {
    on<LoginButtonPressedEvent>(
        (LoginButtonPressedEvent event, Emitter<LoginState> emit) async {
      emit(LoginLoadingState());

      final result = await _loginUser
          .call(AuthParams(email: event.email, password: event.password));

      result.fold(
        (error) => emit(LoginFailureState(error: error.toString())),
        (user) => emit(LoginSuccessState(authUser: user)),
      );
    });
  }
}
