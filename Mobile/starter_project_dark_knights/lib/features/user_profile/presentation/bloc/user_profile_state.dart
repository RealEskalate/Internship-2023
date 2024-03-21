part of 'user_profile_bloc.dart';

abstract class userProfileState extends Equatable {
  const userProfileState();

  @override
  List<Object> get props => [];
}

class ProfileLoading extends userProfileState {}

class ProfileInitial extends userProfileState {}

class ProfileSaving extends userProfileState {}

class ProfileSaved extends userProfileState {}

class ProfileLoaded extends userProfileState {
  final UserEntity user;

  const ProfileLoaded({required this.user});

  @override
  List<Object> get props => [user];
}

class ProfileFailure extends userProfileState {
  final Failure error;

  const ProfileFailure({required this.error});

  @override
  List<Object> get props => [error];
}
