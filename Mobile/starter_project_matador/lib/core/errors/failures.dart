import 'package:equatable/equatable.dart';

abstract class Failure extends Equatable {
  // If the subclasses have some properties, they'll get passed to this constructor
  // so that Equatable can perform value comparison.
  Failure([List properties = const <dynamic>[]]) : super();
}

// class SignUpFailure extends Failure {
//   final String message;

//   SignUpFailure({this.message});

//   @override
//   List<Object> get props => [message];
// }
