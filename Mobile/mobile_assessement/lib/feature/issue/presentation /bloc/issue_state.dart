import 'package:equatable/equatable.dart';
import '../../../../core/errors/failures.dart';
import '../../domain/entities/Issue_entity.dart';

abstract class IssueState extends Equatable {
  const IssueState();

  @override
  List<Object> get props => [];
}

class IssueInitial extends IssueState {}

class IssueLoadingState extends IssueState {}

class IssueLoadedState extends IssueState {
  final List<Issue> issues;

  IssueLoadedState(this.issues);

  @override
  List<Object> get props => [issues];
}


class IssueErrorState extends IssueState {
  final String errorMessage;

  IssueErrorState(this.errorMessage);

  @override
  List<Object> get props => [errorMessage];
}
class IssueSuccessState extends IssueState {
  final List<Issue> issue;

  const IssueSuccessState({required this.issue});

  @override
  List<Object> get props => [issue];
}

class IssueFailureState extends IssueState {
  final Failure error;

  const IssueFailureState({required this.error});

  @override
  List<Object> get props => [error];
}