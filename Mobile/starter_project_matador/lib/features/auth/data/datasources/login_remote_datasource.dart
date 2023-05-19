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
      'https://run.mocky.io/v3/f4fece13-9df3-49ca-a9a4-32b4ba317277';

  LoginRemoteDataSourceImpl({required this.httpClient});

  @override
  Future<LoginModel> authenticate(String email, String password) async {
    // Make API call and handle response, deserializing the data
    // Assume the API returns a JSON object with the user ID
    final response = await httpClient.post(
      Uri.parse('$baseUrl/authenticate'),
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
