part of 'profile_bloc.dart';

abstract class ProfileState extends Equatable {
  const ProfileState();
  
  @override
  List<Object> get props => [];
}

class ProfileInitial extends ProfileState {}


class ProfileLoading extends ProfileState {}

class ProfileSuccess extends ProfileState {

  final UserProfile userProfile ;

  ProfileSuccess({required this.userProfile});

  @override
  List<Object> get props => [userProfile];
}


class ProfileFailure extends ProfileState{
  final Error error ;

  ProfileFailure({required this.error});

  @override
  List<Object> get props => [error];
}