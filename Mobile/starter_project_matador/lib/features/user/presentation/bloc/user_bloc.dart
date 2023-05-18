import 'dart:async';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/usecases/add_user.dart';
import 'package:matador/features/user/domain/usecases/delete_user_by_id.dart';
import 'package:matador/features/user/domain/usecases/edit_user_by_id.dart';
import 'package:matador/features/user/domain/usecases/get_user_by_id.dart';
import 'package:meta/meta.dart';

part 'user_event.dart';

part 'user_state.dart';

class UserBloc extends Bloc<UserEvent, UserState> {
  final AddUser addUser;
  final GetUserById getUserById;
  final EditUserById editUserById;
  final DeleteUserById deleteUserById;

  UserBloc({
    required this.addUser,
    required this.getUserById,
    required this.editUserById,
    required this.deleteUserById,
  }) : super(InitialUserState()) {

    on<GetUserEvent>((event, emit) async {
      emit(LoadingUserState());
      final fetchedUser = await getUserById(event.id);
      fetchedUser.fold(
        (error) => ErrorUserState(message: error.toString()),
        (user) => LoadedUserState(user: user),
      );
    });

    on<AddUserEvent>((event, emit) async {
      emit(LoadingUserState());
      final addedUser = await addUser(event.user);
      addedUser.fold(
        (error) => ErrorUserState(message: error.toString()),
        (user) => LoadedUserState(user: user),
      );
    });

    on<EditUserEvent>((event, emit) async {
      emit(LoadingUserState());
      final updatedUser = await editUserById(event.user);
      updatedUser.fold(
        (error) => ErrorUserState(message: error.toString()),
        (user) => LoadedUserState(user: user),
      );
    });

    on<DeleteUserEvent>((event, emit) async {
      emit(LoadingUserState());
      final deleteOperationResult = await deleteUserById(event.id);
      deleteOperationResult.fold(
        (error) => ErrorUserState(message: error.toString()),
        (success) => InitialUserState(),
      );
    });
  }
}
