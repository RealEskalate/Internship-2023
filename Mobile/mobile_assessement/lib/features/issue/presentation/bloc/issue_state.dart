import 'package:equatable/equatable.dart';
import '../../domain/entities/issue.dart';
class IssueState extends Equatable {
  const IssueState();

  @override
  List<Object> get props => [];
}

class IssueInitial extends IssueState {}

class IssueLoading extends IssueState {}

class IssueLoaded extends IssueState {
  final Issue issue;

  const IssueLoaded({required this.issue});

  @override
  List<Object> get props => [issue];
}

class IssueError extends IssueState {
  final Exception error;

  const IssueError({required this.error});

  @override
  List<Object> get props => [error];
}