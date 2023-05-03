class UserModel {
  String username;
  String firstName;
  String lastName;
  String occupation;
  String selfDescription;
  String image;
  String password;

  // Constructor
  UserModel(
      {required this.username,
      required this.firstName,
      required this.lastName,
      required this.occupation,
      required this.selfDescription,
      required this.image,
      required this.password});

  // Convert JSON to the model
  factory UserModel.fromJson(Map<String, dynamic> json) {
    return UserModel(
        username: json['username'],
        firstName: json['firstName'],
        lastName: json['lastName'],
        occupation: json['occupation'],
        selfDescription: json['selfDescription'],
        image: json['image'],
        password: json['password']);
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
