part of 'profile_bloc.dart';

abstract class ProfileEvent extends Equatable {
  const ProfileEvent();

  @override
  List<Object> get props => [];
}



class GetProfileEvent extends ProfileEvent {

  String id;
  GetProfileEvent({required this.id});

  @override
  List<Object> get props => [id];
}

