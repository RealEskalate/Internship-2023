part of 'user_bloc.dart';

@immutable
abstract class UserEvent extends Equatable {
  const UserEvent() : super();

  @override
  List<Object?> get props => [];
}

class AddUserEvent extends UserEvent {
  final User user;

  const AddUserEvent(this.user) : super();

  @override
  List<Object?> get props => [user];
}

class GetUserEvent extends UserEvent {
  final String id;

  const GetUserEvent(this.id) : super();

  @override
  List<Object?> get props => [id];
}

class EditUserEvent extends UserEvent {
  final User user;

  const EditUserEvent(this.user) : super();

  @override
  List<Object?> get props => [user];
}

class DeleteUserEvent extends UserEvent {
  final String id;

  const DeleteUserEvent(this.id) : super();

  @override
  List<Object?> get props => [id];
}
