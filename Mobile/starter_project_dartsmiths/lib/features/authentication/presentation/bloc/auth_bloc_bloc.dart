import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

import '../../domain/use_cases/login_usecase.dart';

part 'auth_bloc_event.dart';
part 'auth_bloc_state.dart';

class AuthBlocBloc extends Bloc<AuthBlocEvent, AuthBlocState> {
  AuthBlocBloc() : super(AuthBlocInitial()) {
    on<LoginEvent>(_onAuthLoginEvent);
  }

  void _onAuthLoginEvent(LoginEvent event, Emitter emit) {
    emit(AuthBlocLoading());

    final reponse = LoginUsecase
  }
}
