import 'dart:convert';

import 'package:dartz/dartz.dart';

import '../../../../core/error/exceptions.dart';
import '../../../../core/error/failures.dart';
import '../../domain/entity/authentication_payload.dart';
import 'package:http/http.dart' as http;

import '../model/user_auth_credentials.dart';

abstract class AuthenticationRemoteDataSource {
  Future<UserAuthCredentialsModel> login(username, password);
}

class AuthenticationRemoteDataSourceImpl
    implements AuthenticationRemoteDataSource {
  final baseUrl = 'https://mocki.io/v1/cd1346d3-f57d-41c6-aa8c-a0d17eb5d430';
  final http.Client client;

  AuthenticationRemoteDataSourceImpl(this.client);

  @override
  Future<UserAuthCredentialsModel> login(username, password) async {
    try {
      var response = await client.get(Uri.parse(baseUrl));
      var decodedResponse =
          jsonDecode(utf8.decode(response.bodyBytes)) as Map<String, dynamic>;

      return UserAuthCredentialsModel.fromJson(decodedResponse);
    } on Exception catch (_, e) {
      throw ServerException();
    }
  }
}
