part of 'issues_bloc.dart';

abstract class IssueBlocState extends Equatable {
  const IssueBlocState();
  @override
  List<Object> get props => [];
}

class IssueBlocInitial extends IssueBlocState {}
class IssueLoading extends IssueBlocState {}


class IssueLoaded extends IssueBlocState {
  final GetAllInfoDetail alldetail;
  final GetInfoDetail detail;
  IssueLoaded(this.alldetail, this.detail);



}

class IssueFailureState extends IssueBlocState {}

