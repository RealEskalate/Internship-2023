import 'dart:convert';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/features/user/data/models/user_model.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:http/http.dart' as http;

abstract class UserRemoteDataSource {
  Future<UserModel> addUser(UserModel user);
  Future<UserModel> getUserById(String id);
  Future<UserModel> editUserById(UserModel user);
  Future<void> deleteUserById(String id);
}

class UserRemoteDataSourceImpl implements UserRemoteDataSource {
  final http.Client client;

  UserRemoteDataSourceImpl({required this.client});

  @override
  Future<UserModel> addUser(UserModel user) async {
    final url = Uri.parse("http://blogsapi.com/users/${user.id}");

    final response = await client.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode(user.toJson()),
    );
    if (response.statusCode == 200) {
      return UserModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

  @override
  Future<void> deleteUserById(String id) async {
    final url = Uri.parse("http://blogsapi.com/users/$id");
    final response = await client.delete(
      url,
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode != 200) {
      throw ServerException();
    }
  }

  @override
  Future<UserModel> editUserById(UserModel user) async {
    final url = Uri.parse("http://blogsapi.com/users/${user.id}");

    final response = await client.put(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode(user.toJson()),
    );

    if (response.statusCode == 200) {
      return UserModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }

  @override
  Future<UserModel> getUserById(String id) async {
    final url = Uri.parse("http://blogsapi.com/users/$id");
    final response = await client.get(
      url,
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      return UserModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException();
    }
  }
}

