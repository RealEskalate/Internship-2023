part of 'user_profile_bloc.dart';

abstract class ProfileEvent extends Equatable {
  const ProfileEvent();

  @override
  List<Object> get props => [];
}

class UpdateProfileEvent extends ProfileEvent {
  final UserEntity user;

  const UpdateProfileEvent({required this.user});

  @override
  List<Object> get props => [user];
}

class LoadUserEvent extends ProfileEvent {
  final String userId;

  const LoadUserEvent({required this.userId});

  @override
  List<Object> get props => [userId];
}
