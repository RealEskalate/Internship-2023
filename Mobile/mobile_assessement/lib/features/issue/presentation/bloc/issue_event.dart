import 'package:equatable/equatable.dart';

abstract class IssueEvent extends Equatable {
  const IssueEvent();

  @override
  List<Object> get props => [];
}

class IssueRequested extends IssueEvent {}