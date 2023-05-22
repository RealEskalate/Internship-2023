import 'dart:convert';

import 'package:matador/core/error/exception.dart';
import 'package:http/http.dart' as http;

import '../models/login_model.dart';

abstract class LoginRemoteDataSource {
  Future<LoginModel> authenticate(String email, String password);
}

class LoginRemoteDataSourceImpl implements LoginRemoteDataSource {
  final http.Client httpClient;
  final String baseUrl =
      'https://6140a0c9-6919-4996-ae1b-2f2fd8abba5a.mock.pstmn.io';

  LoginRemoteDataSourceImpl({required this.httpClient});

  @override
  Future<LoginModel> authenticate(String email, String password) async {
    // Make API call and handle response, deserializing the data
    // Assume the API returns a JSON object with the user ID
    final response = await httpClient.post(
      Uri.parse('$baseUrl/user'),
      body: {'email': email, 'password': password},
    );

    if (response.statusCode == 200) {
      final responseBody = json.decode(response.body);
      return LoginModel(
        email: email,
        password: password,
        id: responseBody['id'],
      );
    } else {
      // Handle error
      throw ServerException();
    }
  }
}
