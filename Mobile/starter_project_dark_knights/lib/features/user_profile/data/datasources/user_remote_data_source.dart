import 'dart:convert';

import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:http/http.dart' as http;

import '../../../../core/errors/exceptions.dart';

abstract class UserRemoteDataSource {
  Future<List<UserModel>> getAllUsers();

  Future<UserModel> createUser(UserEntity user);

  Future<List<UserModel>> getFollowing(String userId);

  Future<UserModel> editUserProfile(UserEntity user);

  Future<int> getNumberOfFollowers(String userId);

  Future<UserModel> deleteUser(String userId);

  Future<UserModel> getUser(String userId);

  Future<int> getNumberOfFollowing(String userId);

  Future<List<UserModel>> getFollowers(String userId);
}

class UserRemoteDataSourceImpl implements UserRemoteDataSource {
  final http.Client client;
  String uri = "https://api";
  UserRemoteDataSourceImpl({required this.client});
  @override
  Future<UserModel> createUser(UserEntity user) {
    // TODO: implement createUser
    throw UnimplementedError();
  }

  @override
  Future<UserModel> deleteUser(String userId) async {
    final response = await client.delete(Uri.parse('$uri/deleteUser/$userId'),
        headers: {'Content-Type': 'application/json'});
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final user = UserModel.fromJson(jsonResponse);
      return user;
    } else {
      throw ServerException('Failed to delete user');
    }
  }

  @override
  Future<UserModel> editUserProfile(UserEntity user) {
    // TODO: implement editUserProfile
  Future<UserModel> deleteUser(String userId) {
    // TODO: implement deleteUser
    throw UnimplementedError();
  }

  @override
  Future<UserModel> editUserProfile(UserEntity user) async {
    final response = await client.put(
      Uri.parse("http://localhost:3000/"),
      body: user,
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      return UserModel.fromJson(json.decode(response.body));
    } else {
      throw ServerException("Request Succesful");
    }
  }

  @override
  Future<List<UserModel>> getAllUsers() {
    // TODO: implement getAllUsers
    throw UnimplementedError();
  }

  @override
  Future<List<UserModel>> getFollowers(String userId) async {
    final response = await client.get(
      Uri.parse("http://localhost:3000/$userId"),
      headers: {
        'Content-Type': 'application/json',
      },
    );

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final userList = List<Map<String, dynamic>>.from(jsonResponse);
      final followers = userList
          .map((jsonInstance) => UserModel.fromJson(jsonInstance))
          .toList();
      return followers;
    } else {
      throw ServerException("Request Succesful");
    }
  }

  @override
  Future<List<UserModel>> getFollowers(String userId) {
    // TODO: implement getFollowers
    throw UnimplementedError();
  }

  @override
  Future<List<UserModel>> getFollowing(String userId) {
    // TODO: implement getFollowing
    throw UnimplementedError();
  }

  @override
  Future<int> getNumberOfFollowers(String userId) {
    // TODO: implement getNumberOfFollowers
    throw UnimplementedError();
  }

  @override
  Future<int> getNumberOfFollowing(String userId) {
    // TODO: implement getNumberOfFollowing
    throw UnimplementedError();
  }

  @override
  Future<UserModel> getUser(String userId) async {
    // TODO: implement getUser
    final response = await client.get(
      Uri.parse('$uri/getUser/$userId'),
      headers: {'Content-Type': 'application/json'},
    );
    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      final user = UserModel.fromJson(jsonResponse);
      return user;
    } else if (response.statusCode == 404) {
      throw UserNotFoundException('User with ID $userId not found');
    } else {
      throw ServerException(
          'Failed to get user with ID $userId: ${response.reasonPhrase}');
    }
  }
}
