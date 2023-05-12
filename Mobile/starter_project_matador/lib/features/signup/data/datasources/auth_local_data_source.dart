import '../models/user_model.dart';

abstract class AuthLocalDataSource {
  Future<UserModel> getLastUser();
  Future<void> cacheUser(UserModel userModel);
}
