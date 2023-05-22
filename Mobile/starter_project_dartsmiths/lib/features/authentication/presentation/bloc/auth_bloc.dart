import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/error/failures.dart';
import '../../domain/use_cases/login_usecase.dart';

part 'auth_bloc_event.dart';
part 'auth_bloc_state.dart';

class AuthBloc extends Bloc<AuthBlocEvent, AuthBlocState> {
  final LoginUsecase loginUsecase;

  AuthBloc(this.loginUsecase) : super(AuthBlocInitial()) {
    on<LoginEvent>(_onAuthLoginEvent);
  }

  void _onAuthLoginEvent(LoginEvent event, Emitter emit) async {
    emit(AuthBlocLoading());

    final failureOrAuthCredentials = await loginUsecase(
        UserAuthCredentialParams(
            username: event.username, password: event.password));

    emit(_loginOrFailure(failureOrAuthCredentials));
  }

  _loginOrFailure(both) {
    return both.fold(
      (failure) => ServerFailure(),
      (authCredential) => AuthBlocLoginSuccess(
          username: authCredential.username, password: authCredential.password),
    );
  }
}
