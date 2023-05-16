import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../../../core/error/failures.dart';
import '../models/user_profile_models.dart';

abstract class UserProfileRemoteDataSource {
  Future<UserProfileModel> getUserProfile(String id);
}

class UserProfileRemoteDataSourceImpl implements UserProfileRemoteDataSource {
  var client = http.Client();

  UserProfileRemoteDataSourceImpl(this.client);
  @override
  Future<UserProfileModel> getUserProfile(String id) async {
    final response = await client.get(
      Uri.parse('uri'),
      headers: {'Content-Type': 'application/json'},
    );

    if (response.statusCode == 200) {
      return UserProfileModel.fromJson(json.decode(response.body));
    } else {
      throw ServerFailure();
    }
  }
}
