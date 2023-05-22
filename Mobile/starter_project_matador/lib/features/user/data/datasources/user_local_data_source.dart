import 'package:matador/features/user/data/models/user_model.dart';

abstract class UserLocalDataSource {
  Future<UserModel> getLastUser();
  Future<void> cacheUser(UserModel userToCache);

}

