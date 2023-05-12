import 'package:dark_knights/features/user_profile/data/models/user_model.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';

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
