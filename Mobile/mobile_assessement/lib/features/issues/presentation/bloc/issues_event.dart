part of 'issues_bloc.dart';
@immutable
abstract class IssueBlocEvent extends Equatable {

  @override
  List<Object> get props => [];
}

class LoadIssueEvent extends IssueBlocEvent {
  final String id;

  LoadIssueEvent({required this.id});

  @override
  List<Object> get props => [id];
}


class LoadAllIssueEvent extends IssueBlocEvent {
  

  LoadAllIssueEvent();

  @override
  List<Object> get props => [];
}

