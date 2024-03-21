import 'package:dark_knights/features/user_profile/data/models/user_model.dart';

abstract class UserLocalDataSource {
  Future<UserModel> getLoggedInUser();
  Future<void> cacheLoggedInUser();
}
