import 'package:equatable/equatable.dart';
abstract class Failure extends Equatable {
  Failure([List properties = const <dynamic>[]]) : super();

  @override
  List<Object> get props => [];
}

class ServerFailure extends Failure {
  final String message;
  ServerFailure(this.message);
}
class WeatherDataNotFoundFailure extends Failure {
  final String message;
 WeatherDataNotFoundFailure(this.message);
}
