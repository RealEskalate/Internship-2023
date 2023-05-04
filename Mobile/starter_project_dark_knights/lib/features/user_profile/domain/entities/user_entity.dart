import 'package:equatable/equatable.dart';

class UserEntity extends Equatable {
  final int id;
  final String username;
  final String firstName;
  final String lastName;
  final String occupation;
  final String selfDescription;
  final String password;
  final String image;

UserEntity({
    required this.id,
    required this.username,
    required this.firstName,
    required this.lastName,
    required this.occupation,
    required this.selfDescription,
    required this.password,
    required this.image,
  });

  @override
  List<Object?> get props => [id, username, firstName, lastName,occupation,selfDescription,password,image];
}