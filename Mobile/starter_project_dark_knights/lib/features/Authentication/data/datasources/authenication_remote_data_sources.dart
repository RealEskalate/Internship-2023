import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/errors/exception.dart';
import '../../domain/entities/authentication_entitiy.dart';
import '../models/authentication.dart';

abstract class AuthenticationRemoteDataSource {
  Future<AuthenticationModel> signup(Authentication newuser);
  Future<AuthenticationModel> login(Authentication user);
}

class AuthenticationRemoteDataSourceImpl
    implements AuthenticationRemoteDataSource {
  final http.Client client;
  String uri = "http://localhost:3000";

  AuthenticationRemoteDataSourceImpl({required this.client});

  @override
  Future<AuthenticationModel> login(Authentication user) async {
    final response = await client.post(
      Uri.parse('$uri/login'),
      body:
          user, // Assuming `toJson()` method is implemented in the `AuthenticationModel` class
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      return AuthenticationModel.fromJson(data);
    } else {
      throw ServerException(
          'Failed to login'); // Update the error message if desired
    }
  }

  @override
  Future<AuthenticationModel> signup(Authentication newuser) async {
    // TODO: implement signup
    final response = await client.post(
      Uri.parse('$uri/signup'),
      body:
          newuser, // Assuming `toJson()` method is implemented in the `AuthenticationModel` class
      headers: {
        'Content-Type': 'application/json',
      },
    );
    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      return AuthenticationModel.fromJson(data);
    } else {
      throw ServerException(
          'Failed to Signup'); // Update the error message if desired
    }
  }
}
