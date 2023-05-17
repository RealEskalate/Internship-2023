part of 'home_bloc.dart';

abstract class HomeState extends Equatable {
  const HomeState();

  @override
  List<Object> get props => [];
}

class InitialState extends HomeState {}

class LoadingState extends HomeState {}

class SuccessState extends HomeState {
  final List<Home> homeData;
  const SuccessState({required this.homeData});

  @override
  List<Object> get props => [homeData];
}

class FailureState extends HomeState {
  final String message;

  const FailureState(this.message);
  @override
  List<Object> get props => [message];
  
}
