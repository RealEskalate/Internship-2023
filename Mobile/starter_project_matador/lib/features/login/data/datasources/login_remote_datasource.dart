import 'dart:convert';

import 'package:matador/core/error/exception.dart';
import 'package:matador/features/login/Domain/entities/user.dart';
import 'package:http/http.dart' as http;

import '../models/login_model.dart';

abstract class LoginUserRemoteDataSource {
  Future<LoginModel> authenticate(User user);
}

class LoginUserRemoteDataSourceImpl implements LoginUserRemoteDataSource {
  final http.Client client;
  final String _baseUrl = 'https://blogapi/';
  LoginUserRemoteDataSourceImpl({required this.client});
  @override
  Future<LoginModel> authenticate(User loginuser) async {
    final loginModel = loginuser as LoginModel;
    final response = await client.post(
      Uri.parse('${_baseUrl}login'),
      headers: {'Content-Type': 'application/json'},
      body: json.encode(loginModel.toJson()),
    );
    if (response.statusCode == 200) {
      return LoginModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }
}
