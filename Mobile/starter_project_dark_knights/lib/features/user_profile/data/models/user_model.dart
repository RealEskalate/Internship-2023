
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';

class UserModel extends UserEntity{
   final String id;
  final String username;
  final String firstName;
  final String lastName;
  final String occupation;
  final String selfDescription;
  final String password;
  final String image;


  // Constructor
  UserModel({
    required this.id,
    required this.username,
    required this.firstName,
    required this.lastName,
    required this.occupation,
    required this.selfDescription,
    required this.password,
    required this.image,
  }): super(id:id,username: username,firstName: firstName,lastName: lastName,
  occupation: occupation,selfDescription: selfDescription,password: password,image:image );

  // Convert JSON to the model
  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
      id:json['id'],
      username: json['username'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      occupation: json['occupation'],
      selfDescription: json['selfDescription'],
      image: json['image'],
      password: json['password']
    );
  }

  // Convert the model to JSON
  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['username'] = username;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['occupation'] = occupation;
    data['selfDescription'] = selfDescription;
    data['image'] = image;
    data['password'] = password;
    return data;
  }
}