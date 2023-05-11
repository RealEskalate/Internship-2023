class Authentication {
  String id;
  String userName;
  String password;

  Authentication(
      {required this.id, required this.userName, required this.password});

  factory Authentication.fromJson(Map<String, dynamic> json) {
    return Authentication(
      id: json['id'],
      userName: json['UserName'],
      password: json['password'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'UserName': userName,
      'password': password,
    };
  }
}
