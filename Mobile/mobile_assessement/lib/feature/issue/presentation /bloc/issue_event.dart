import 'package:equatable/equatable.dart';

abstract class IssueEvent extends Equatable {
  const IssueEvent();

  @override
  List<Object> get props => [];
}

class GetAllIssuesEvent extends IssueEvent {}

class GetIssueByIdEvent extends IssueEvent {
  final String id;

  const GetIssueByIdEvent(this.id);

  @override
  List<Object> get props => [id];
}