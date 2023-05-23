part of 'detail_bloc.dart';

abstract class DetailState extends Equatable {
  const DetailState();

  @override
  List<Object> get props => [];
}

class DetailInitial extends DetailState {}

class DetailLoading extends DetailState {}

class DetailSuccess extends DetailState {
  final HomeDetail homeDetail;
  DetailSuccess({required this.homeDetail});
  @override
  List<Object> get props => [homeDetail];

}
class DetailFailure extends DetailState{
  final Error error ;

  DetailFailure({required this.error});

  @override
  List<Object> get props => [error];
}