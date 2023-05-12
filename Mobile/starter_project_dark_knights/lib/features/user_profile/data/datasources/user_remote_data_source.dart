import 'package:dark_knights/features/user_profile/data/models/user_model.dart';

abstract class UserRemoteDataSource {
  Future<List<UserModel>> getAllUsers();

  Future<UserModel> createUser(UserModel user);

  Future<List<UserModel>> getFollowing(String userId);

  Future<UserModel> editUserProfile(UserModel user);

  Future<int> getNumberOfFollowers(String userId);

  Future<UserModel> deleteUser(String userId);

  Future<UserModel> getUser(String userId);

  Future<int> getNumberOfFollowing(String userId);

  Future<List<UserModel>> getFollowers(String userId);
}
