
class UserProfile {
  String username;
  String firstName;
  String lastName;
  String occupation;
  String selfDescription;

  // Constructor
  UserProfile({
    required this.username,
    required this.firstName,
    required this.lastName,
    required this.occupation,
    required this.selfDescription,
  });

  // Convert JSON to the model
  factory UserProfile.fromJson(Map<String, dynamic> json) {
    return UserProfile(
      username: json['username'],
      firstName: json['firstName'],
      lastName: json['lastName'],
      occupation: json['occupation'],
      selfDescription: json['selfDescription'],
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
    return data;
  }
}