import 'package:equatable/equatable.dart';

// class UserAuthCredential extends Equatable {
//   final String username;
//   final String password;

//   const UserAuthCredential({required this.username, required this.password});
//   @override
//   List<Object> get props => [username, password];
// }

class UserAuthCredential extends Equatable {
  final String username;
  final String password;

  const UserAuthCredential({required this.username, required this.password});
  @override
  List<Object> get props => [username, password];
}
