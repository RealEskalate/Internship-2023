import 'package:equatable/equatable.dart';

class UserEntity extends Equatable {
  final int id;
  final String username;
  final String firstName;
  final String lastName;
  final String occupation;
  final String selfDescription;

UserEntity({
    required this.id,
    required this.username,
    required this.firstName,
    required this.lastName,
    required this.occupation,
    required this.selfDescription,
  });

  @override
  List<Object?> get props => [id, username, firstName, lastName,occupation,selfDescription];
}