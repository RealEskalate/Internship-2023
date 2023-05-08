import 'package:equatable/equatable.dart';

abstract class Failure extends Equatable {
  const Failure([List properties = const <dynamic>[]]);
}

class InvalidEmailFailure extends Failure {
  const InvalidEmailFailure() : super();

  @override
  List<Object?> get props => [];

  @override
  String toString() => 'Invalid Email';
}

class InvalidPasswordFailure extends Failure {
  const InvalidPasswordFailure() : super();

  @override
  List<Object?> get props => [];

  @override
  String toString() => 'Invalid Password';
}
